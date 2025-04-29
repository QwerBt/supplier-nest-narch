using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyImages.Commands.Delete;

public class DeletedCompanyImageResponse : IResponse
{
    public Guid Id { get; set; }
}