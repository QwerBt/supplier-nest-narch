using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyBrands.Commands.Delete;

public class DeletedCompanyBrandResponse : IResponse
{
    public int Id { get; set; }
}