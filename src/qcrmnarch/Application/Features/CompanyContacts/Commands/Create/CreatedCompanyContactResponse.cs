using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyContacts.Commands.Create;

public class CreatedCompanyContactResponse : IResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Phone1 { get; set; }
    public string Phone2 { get; set; }
    public string Email { get; set; }
    public string Position { get; set; }
    public bool IsPrimary { get; set; }
    public int CompanyId { get; set; }
}