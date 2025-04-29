using Application.Features.Items.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Items;

public class ItemManager : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly ItemBusinessRules _itemBusinessRules;

    public ItemManager(IItemRepository itemRepository, ItemBusinessRules itemBusinessRules)
    {
        _itemRepository = itemRepository;
        _itemBusinessRules = itemBusinessRules;
    }

    public async Task<Item?> GetAsync(
        Expression<Func<Item, bool>> predicate,
        Func<IQueryable<Item>, IIncludableQueryable<Item, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Item? item = await _itemRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return item;
    }

    public async Task<IPaginate<Item>?> GetListAsync(
        Expression<Func<Item, bool>>? predicate = null,
        Func<IQueryable<Item>, IOrderedQueryable<Item>>? orderBy = null,
        Func<IQueryable<Item>, IIncludableQueryable<Item, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Item> itemList = await _itemRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return itemList;
    }

    public async Task<Item> AddAsync(Item item)
    {
        Item addedItem = await _itemRepository.AddAsync(item);

        return addedItem;
    }

    public async Task<Item> UpdateAsync(Item item)
    {
        Item updatedItem = await _itemRepository.UpdateAsync(item);

        return updatedItem;
    }

    public async Task<Item> DeleteAsync(Item item, bool permanent = false)
    {
        Item deletedItem = await _itemRepository.DeleteAsync(item);

        return deletedItem;
    }
}
