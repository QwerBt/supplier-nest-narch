using NArchitecture.Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.CompanyUsers.Commands.Update;

public class UpdatedCompanyUserResponse : IResponse
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}