using Application.Features.Items.Queries.GetList;
using Domain.Entities;
using NArchitecture.Core.Application.Dtos;
using System.Text.Json.Serialization;

namespace Application.Features.Products.Queries.GetList;

public class GetListProductListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ItemCount { get; set; }




}