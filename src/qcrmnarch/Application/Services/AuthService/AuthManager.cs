using System.Collections.Immutable;
using System.Linq;
using Application.Features.Auth.Commands.GoogleLogin;
using Application.Features.Auth.Commands.Login;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using NArchitecture.Core.Security.Entities;
using NArchitecture.Core.Security.JWT;

namespace Application.Services.AuthService;

public class AuthManager : IAuthService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ITokenHelper<Guid, int, Guid> _tokenHelper;
    private readonly NArchitecture.Core.Security.JWT.TokenOptions _tokenOptions;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    private IUserOperationClaimRepository _userOperationClaimRepository1;
    private IRefreshTokenRepository _refreshTokenRepository1;

    public AuthManager(
        IUserOperationClaimRepository userOperationClaimRepository,
        IRefreshTokenRepository refreshTokenRepository,
        ITokenHelper<Guid, int, Guid> tokenHelper,
        IConfiguration configuration,
        IMapper mapper,
        IUserService userService

    )
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _tokenHelper = tokenHelper;
        const string tokenOptionsConfigurationSection = "TokenOptions";
        _tokenOptions =
            configuration.GetSection(tokenOptionsConfigurationSection).Get<NArchitecture.Core.Security.JWT.TokenOptions>()
            ?? throw new NullReferenceException($"\"{tokenOptionsConfigurationSection}\" section cannot found in configuration");

        _mapper = mapper;
        _userService = userService;

    }

    public AuthManager(ITokenHelper<Guid, int, Guid> tokenHelper, IConfiguration configuration, IMapper mapper)
    {
        _tokenHelper = tokenHelper;
        _configuration = configuration;
        _mapper = mapper;
    }

    public AuthManager(IUserOperationClaimRepository userOperationClaimRepository1, IRefreshTokenRepository refreshTokenRepository1, ITokenHelper<Guid, int, Guid> tokenHelper, IConfiguration configuration, IMapper mapper)
    {
        _userOperationClaimRepository1 = userOperationClaimRepository1;
        _refreshTokenRepository1 = refreshTokenRepository1;
        _tokenHelper = tokenHelper;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        IList<OperationClaim> operationClaims = await _userOperationClaimRepository.GetOperationClaimsByUserIdAsync(user.Id);
        AccessToken accessToken = _tokenHelper.CreateToken(
            user,
            operationClaims.Select(op => (NArchitecture.Core.Security.Entities.OperationClaim<int>)op).ToImmutableList()
        );
        return accessToken;
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
        return addedRefreshToken;
    }

    public async Task DeleteOldRefreshTokens(Guid userId)
    {
        List<RefreshToken> refreshTokens = await _refreshTokenRepository.GetOldRefreshTokensAsync(
            userId,
            _tokenOptions.RefreshTokenTTL
        );
        await _refreshTokenRepository.DeleteRangeAsync(refreshTokens);
    }

    public async Task<RefreshToken?> GetRefreshTokenByToken(string token)
    {
        RefreshToken? refreshToken = await _refreshTokenRepository.GetAsync(predicate: r => r.Token == token);
        return refreshToken;
    }

    public async Task RevokeRefreshToken(
        RefreshToken refreshToken,
        string ipAddress,
        string? reason = null,
        string? replacedByToken = null
    )
    {
        refreshToken.RevokedDate = DateTime.UtcNow;
        refreshToken.RevokedByIp = ipAddress;
        refreshToken.ReasonRevoked = reason;
        refreshToken.ReplacedByToken = replacedByToken;
        await _refreshTokenRepository.UpdateAsync(refreshToken);

    }

    public async Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress)
    {
        NArchitecture.Core.Security.Entities.RefreshToken<Guid, Guid> newCoreRefreshToken = _tokenHelper.CreateRefreshToken(
            user,
            ipAddress
        );
        RefreshToken newRefreshToken = _mapper.Map<RefreshToken>(newCoreRefreshToken);
        await RevokeRefreshToken(refreshToken, ipAddress, reason: "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }

    public async Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason)
    {
        RefreshToken? childToken = await _refreshTokenRepository.GetAsync(predicate: r =>
            r.Token == refreshToken.ReplacedByToken
        );

        if (childToken?.RevokedDate != null && childToken.ExpirationDate <= DateTime.UtcNow)
            await RevokeRefreshToken(childToken, ipAddress, reason);
        else
            await RevokeDescendantRefreshTokens(refreshToken: childToken!, ipAddress, reason);
    }

    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        NArchitecture.Core.Security.Entities.RefreshToken<Guid, Guid> coreRefreshToken = _tokenHelper.CreateRefreshToken(
            user,
            ipAddress
        );
        RefreshToken refreshToken = _mapper.Map<RefreshToken>(coreRefreshToken);
        return Task.FromResult(refreshToken);
    }

    public async Task<GoogleLoginResponse> GoogleLoginAsync(string idToken)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string> { "462867339290-7lopj64nmhp09hfhp0p8e2ahn2ng3kcl.apps.googleusercontent.com" }
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);


        if (payload == null)
        {
            return null; // Google token validation failed
        }
        var user = await _userService.GetAsync(u => u.Email == payload.Email);

        // Google'dan alınan bilgilere göre AuthResponse oluşturuluyor
        return new GoogleLoginResponse
        {
            AccessToken = await CreateUserExternalAsync(user, payload.Email, payload.Name),
        };

    }

    async Task<AccessToken> CreateUserExternalAsync(User user, string email, string name)
    {
        bool result = user != null;



            if (user == null)
            {
                // Yeni kullanıcı oluştur
                user = new User
                {
                    Id = Guid.NewGuid(),  // Kullanıcıya yeni bir GUID id atıyoruz
                    Email = email,
                    FirstName = name, // Google'dan alınan isim
                    LastName =name   // Google'dan alınan soyisim                    
                };

                // Kullanıcıyı veritabanına ekleyin
                var userResult = await _userService.AddAsync(user);

                // Kullanıcı başarıyla eklenirse
                if (userResult != null)
                {
                    result = true; // Başarılı bir şekilde kullanıcı eklendi
                }
                else
                {
                    result = false; // Kullanıcı oluşturulamadı
                    throw new Exception("User creation failed");
                }
            }
      

        if (result)
        {
            // Domain.Entities.OperationClaim tipindeki listeyi alıyoruz
            IList<Domain.Entities.OperationClaim> domainClaims = await _userOperationClaimRepository.GetOperationClaimsByUserIdAsync(user.Id);

            // Kullanıcı için operation claims'i int tipine dönüştürüyoruz
            IList<OperationClaim<int>> operationClaimsInt = domainClaims
                .Select(domainClaim => new NArchitecture.Core.Security.Entities.OperationClaim<int>(
                   new Guid(domainClaim.Id.ToString()).GetHashCode(), 
                    domainClaim.Name
                ))
                .ToList();

            // CreateToken metodunu çağırarak erişim token'ı oluşturuyoruz
            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaimsInt);

            // Refresh token'ı oluşturulmalı ve veritabanına kaydedilmeli
            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),  // Yeni bir refresh token oluştur
                UserId = user.Id,  // Kullanıcı ID'si doğru şekilde atanmalı
                //Expiration = DateTime.UtcNow.AddMinutes(_tokenOptions.RefreshTokenTTL) // TTL süresi verilmeli
            };

            // Refresh token'ı veritabanına kaydediyoruz
            await _refreshTokenRepository.AddAsync(refreshToken);

            // Erişim token'ı ve refresh token'ı birlikte döndürüyoruz
            return new AccessToken
            {
                Token = accessToken.Token,
                ExpirationDate = accessToken.ExpirationDate,
            };
        }

        throw new Exception("Invalid external authentication.");  // Hata durumunda exception fırlat
    }

}
