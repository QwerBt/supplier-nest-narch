using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyUsers.Commands.Delete;

public class DeletedCompanyUserResponse : IResponse
{
    public int Id { get; set; }
}