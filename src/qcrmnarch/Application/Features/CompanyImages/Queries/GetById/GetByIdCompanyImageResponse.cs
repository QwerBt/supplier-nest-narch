using NArchitecture.Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.CompanyImages.Queries.GetById;

public class GetByIdCompanyImageResponse : IResponse
{
    public Guid Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
}