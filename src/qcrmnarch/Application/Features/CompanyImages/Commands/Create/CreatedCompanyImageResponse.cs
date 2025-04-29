using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyImages.Commands.Create;

public class CreatedCompanyImageResponse : IResponse
{
    public Guid Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
}