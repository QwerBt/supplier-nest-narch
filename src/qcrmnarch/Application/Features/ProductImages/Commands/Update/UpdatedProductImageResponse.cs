using NArchitecture.Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.ProductImages.Commands.Update;

public class UpdatedProductImageResponse : IResponse
{
    public Guid Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
}