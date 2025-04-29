using NArchitecture.Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.ProductImages.Queries.GetList;

public class GetListProductImageListItemDto : IDto
{
    public Guid Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
}