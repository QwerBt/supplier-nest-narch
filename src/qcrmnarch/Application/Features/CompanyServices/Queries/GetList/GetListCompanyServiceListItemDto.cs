using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CompanyServices.Queries.GetList;

public class GetListCompanyServiceListItemDto : IDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public int ServicesId { get; set; }
    public Service Service { get; set; }
}