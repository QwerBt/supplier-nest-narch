using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyServices.Commands.Update;

public class UpdatedCompanyServiceResponse : IResponse
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public int ServicesId { get; set; }
    public Service Service { get; set; }
}