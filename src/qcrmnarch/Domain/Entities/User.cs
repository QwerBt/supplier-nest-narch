namespace Domain.Entities;

public class User : NArchitecture.Core.Security.Entities.User<Guid>
{

    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    // Name özelliğini FirstName ve LastName ile birleştirerek döndür
    public string Name
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;
    public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = default!;
    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = default!;
    // Kullanıcının sahip olduğu roller
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
