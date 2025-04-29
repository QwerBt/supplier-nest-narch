using Application.Features.ItemUoms.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ItemUoms;

public class ItemUomManager : IItemUomService
{
    private readonly IItemUomRepository _itemUomRepository;
    private readonly ItemUomBusinessRules _itemUomBusinessRules;

    public ItemUomManager(IItemUomRepository itemUomRepository, ItemUomBusinessRules itemUomBusinessRules)
    {
        _itemUomRepository = itemUomRepository;
        _itemUomBusinessRules = itemUomBusinessRules;
    }

    public async Task<ItemUom?> GetAsync(
        Expression<Func<ItemUom, bool>> predicate,
        Func<IQueryable<ItemUom>, IIncludableQueryable<ItemUom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ItemUom? itemUom = await _itemUomRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return itemUom;
    }

    public async Task<IPaginate<ItemUom>?> GetListAsync(
        Expression<Func<ItemUom, bool>>? predicate = null,
        Func<IQueryable<ItemUom>, IOrderedQueryable<ItemUom>>? orderBy = null,
        Func<IQueryable<ItemUom>, IIncludableQueryable<ItemUom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ItemUom> itemUomList = await _itemUomRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return itemUomList;
    }

    public async Task<ItemUom> AddAsync(ItemUom itemUom)
    {
        ItemUom addedItemUom = await _itemUomRepository.AddAsync(itemUom);

        return addedItemUom;
    }

    public async Task<ItemUom> UpdateAsync(ItemUom itemUom)
    {
        ItemUom updatedItemUom = await _itemUomRepository.UpdateAsync(itemUom);

        return updatedItemUom;
    }

    public async Task<ItemUom> DeleteAsync(ItemUom itemUom, bool permanent = false)
    {
        ItemUom deletedItemUom = await _itemUomRepository.DeleteAsync(itemUom);

        return deletedItemUom;
    }
}
