using Application.Features.Specifications.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Specifications;

public class SpecificationManager : ISpecificationService
{
    private readonly ISpecificationRepository _specificationRepository;
    private readonly SpecificationBusinessRules _specificationBusinessRules;

    public SpecificationManager(ISpecificationRepository specificationRepository, SpecificationBusinessRules specificationBusinessRules)
    {
        _specificationRepository = specificationRepository;
        _specificationBusinessRules = specificationBusinessRules;
    }

    public async Task<Specification?> GetAsync(
        Expression<Func<Specification, bool>> predicate,
        Func<IQueryable<Specification>, IIncludableQueryable<Specification, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Specification? specification = await _specificationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return specification;
    }

    public async Task<IPaginate<Specification>?> GetListAsync(
        Expression<Func<Specification, bool>>? predicate = null,
        Func<IQueryable<Specification>, IOrderedQueryable<Specification>>? orderBy = null,
        Func<IQueryable<Specification>, IIncludableQueryable<Specification, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Specification> specificationList = await _specificationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return specificationList;
    }

    public async Task<Specification> AddAsync(Specification specification)
    {
        Specification addedSpecification = await _specificationRepository.AddAsync(specification);

        return addedSpecification;
    }

    public async Task<Specification> UpdateAsync(Specification specification)
    {
        Specification updatedSpecification = await _specificationRepository.UpdateAsync(specification);

        return updatedSpecification;
    }

    public async Task<Specification> DeleteAsync(Specification specification, bool permanent = false)
    {
        Specification deletedSpecification = await _specificationRepository.DeleteAsync(specification);

        return deletedSpecification;
    }
}
