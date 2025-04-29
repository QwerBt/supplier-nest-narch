using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyAddresses.Commands.Delete;

public class DeletedCompanyAddressResponse : IResponse
{
    public int Id { get; set; }
}