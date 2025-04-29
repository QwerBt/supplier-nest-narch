using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyContacts.Commands.Delete;

public class DeletedCompanyContactResponse : IResponse
{
    public int Id { get; set; }
}