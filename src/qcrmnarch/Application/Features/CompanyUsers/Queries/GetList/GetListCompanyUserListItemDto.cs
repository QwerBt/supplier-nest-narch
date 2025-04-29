using NArchitecture.Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.CompanyUsers.Queries.GetList;

public class GetListCompanyUserListItemDto : IDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}