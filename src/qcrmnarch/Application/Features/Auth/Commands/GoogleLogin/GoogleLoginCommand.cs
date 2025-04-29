using Application.Features.Auth.Constants;
using Application.Features.Auth.Rules;
using AutoMapper;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Auth.Constants.AuthOperationClaims;
using Application.Services.AuthService;

namespace Application.Features.Auth.Commands.GoogleLogin;

public class GoogleLoginCommand : IRequest<GoogleLoginResponse> 
{
    public string Id { get; set; }
    public string IdToken { get; set; }
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhotoUrl { get; set; }
    public string Provider { get; set; }


    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommand, GoogleLoginResponse>
    {
        private readonly IMapper _mapper;
        private readonly AuthBusinessRules _authBusinessRules;
        readonly IAuthService _authService;


        public GoogleLoginCommandHandler(IMapper mapper, AuthBusinessRules authBusinessRules,IAuthService authService)
        {
            _mapper = mapper;
            _authBusinessRules = authBusinessRules;
            _authService = authService;
        }

        public async Task<GoogleLoginResponse> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
        {

            return await _authService.GoogleLoginAsync(request.IdToken);

        }
    }
}
