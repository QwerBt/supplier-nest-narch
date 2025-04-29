using Application.Features.ItemSpecifications.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ItemSpecifications;

public class ItemSpecificationManager : IItemSpecificationService
{
    private readonly IItemSpecificationRepository _itemSpecificationRepository;
    private readonly ItemSpecificationBusinessRules _itemSpecificationBusinessRules;

    public ItemSpecificationManager(IItemSpecificationRepository itemSpecificationRepository, ItemSpecificationBusinessRules itemSpecificationBusinessRules)
    {
        _itemSpecificationRepository = itemSpecificationRepository;
        _itemSpecificationBusinessRules = itemSpecificationBusinessRules;
    }

    public async Task<ItemSpecification?> GetAsync(
        Expression<Func<ItemSpecification, bool>> predicate,
        Func<IQueryable<ItemSpecification>, IIncludableQueryable<ItemSpecification, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ItemSpecification? itemSpecification = await _itemSpecificationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return itemSpecification;
    }

    public async Task<IPaginate<ItemSpecification>?> GetListAsync(
        Expression<Func<ItemSpecification, bool>>? predicate = null,
        Func<IQueryable<ItemSpecification>, IOrderedQueryable<ItemSpecification>>? orderBy = null,
        Func<IQueryable<ItemSpecification>, IIncludableQueryable<ItemSpecification, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ItemSpecification> itemSpecificationList = await _itemSpecificationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return itemSpecificationList;
    }

    public async Task<ItemSpecification> AddAsync(ItemSpecification itemSpecification)
    {
        ItemSpecification addedItemSpecification = await _itemSpecificationRepository.AddAsync(itemSpecification);

        return addedItemSpecification;
    }

    public async Task<ItemSpecification> UpdateAsync(ItemSpecification itemSpecification)
    {
        ItemSpecification updatedItemSpecification = await _itemSpecificationRepository.UpdateAsync(itemSpecification);

        return updatedItemSpecification;
    }

    public async Task<ItemSpecification> DeleteAsync(ItemSpecification itemSpecification, bool permanent = false)
    {
        ItemSpecification deletedItemSpecification = await _itemSpecificationRepository.DeleteAsync(itemSpecification);

        return deletedItemSpecification;
    }
}
