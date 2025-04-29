using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CompanyImages.Queries.GetList;

public class GetListCompanyImageListItemDto : IDto
{
    public Guid Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
}