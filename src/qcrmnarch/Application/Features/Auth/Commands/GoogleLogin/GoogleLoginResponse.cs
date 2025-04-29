using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Security.Enums;
using NArchitecture.Core.Security.JWT;


namespace Application.Features.Auth.Commands.GoogleLogin;

public class GoogleLoginResponse : IResponse { 
    public string UserId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public AccessToken AccessToken { get; set; }
    public Domain.Entities.RefreshToken? RefreshToken { get; set; }
    public bool Status { get; set; }

    public AuthenticatorType? RequiredAuthenticatorType { get; set; }

    public GoogleLoggedHttpResponse ToHttpResponse()
    {
        return new() { AccessToken = AccessToken, RequiredAuthenticatorType = RequiredAuthenticatorType };
    }

    public class GoogleLoggedHttpResponse
    {
        public AccessToken? AccessToken { get; set; }
        public AuthenticatorType? RequiredAuthenticatorType { get; set; }
    }


}
