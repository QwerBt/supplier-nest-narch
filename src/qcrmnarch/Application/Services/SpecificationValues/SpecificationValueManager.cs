using Application.Features.SpecificationValues.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SpecificationValues;

public class SpecificationValueManager : ISpecificationValueService
{
    private readonly ISpecificationValueRepository _specificationValueRepository;
    private readonly SpecificationValueBusinessRules _specificationValueBusinessRules;

    public SpecificationValueManager(ISpecificationValueRepository specificationValueRepository, SpecificationValueBusinessRules specificationValueBusinessRules)
    {
        _specificationValueRepository = specificationValueRepository;
        _specificationValueBusinessRules = specificationValueBusinessRules;
    }

    public async Task<SpecificationValue?> GetAsync(
        Expression<Func<SpecificationValue, bool>> predicate,
        Func<IQueryable<SpecificationValue>, IIncludableQueryable<SpecificationValue, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SpecificationValue? specificationValue = await _specificationValueRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return specificationValue;
    }

    public async Task<IPaginate<SpecificationValue>?> GetListAsync(
        Expression<Func<SpecificationValue, bool>>? predicate = null,
        Func<IQueryable<SpecificationValue>, IOrderedQueryable<SpecificationValue>>? orderBy = null,
        Func<IQueryable<SpecificationValue>, IIncludableQueryable<SpecificationValue, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SpecificationValue> specificationValueList = await _specificationValueRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return specificationValueList;
    }

    public async Task<SpecificationValue> AddAsync(SpecificationValue specificationValue)
    {
        SpecificationValue addedSpecificationValue = await _specificationValueRepository.AddAsync(specificationValue);

        return addedSpecificationValue;
    }

    public async Task<SpecificationValue> UpdateAsync(SpecificationValue specificationValue)
    {
        SpecificationValue updatedSpecificationValue = await _specificationValueRepository.UpdateAsync(specificationValue);

        return updatedSpecificationValue;
    }

    public async Task<SpecificationValue> DeleteAsync(SpecificationValue specificationValue, bool permanent = false)
    {
        SpecificationValue deletedSpecificationValue = await _specificationValueRepository.DeleteAsync(specificationValue);

        return deletedSpecificationValue;
    }
}
