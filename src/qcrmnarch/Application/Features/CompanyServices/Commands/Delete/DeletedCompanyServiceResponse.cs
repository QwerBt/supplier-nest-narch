using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyServices.Commands.Delete;

public class DeletedCompanyServiceResponse : IResponse
{
    public int Id { get; set; }
}