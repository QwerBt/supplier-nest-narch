using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductImages.Commands.Create;

public class CreatedProductImageResponse : IResponse
{
    public Guid Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
}