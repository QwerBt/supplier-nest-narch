using Application.Features.Industries.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Industries;

public class IndustryManager : IIndustryService
{
    private readonly IIndustryRepository _industryRepository;
    private readonly IndustryBusinessRules _industryBusinessRules;

    public IndustryManager(IIndustryRepository industryRepository, IndustryBusinessRules industryBusinessRules)
    {
        _industryRepository = industryRepository;
        _industryBusinessRules = industryBusinessRules;
    }

    public async Task<Industry?> GetAsync(
        Expression<Func<Industry, bool>> predicate,
        Func<IQueryable<Industry>, IIncludableQueryable<Industry, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Industry? industry = await _industryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return industry;
    }

    public async Task<IPaginate<Industry>?> GetListAsync(
        Expression<Func<Industry, bool>>? predicate = null,
        Func<IQueryable<Industry>, IOrderedQueryable<Industry>>? orderBy = null,
        Func<IQueryable<Industry>, IIncludableQueryable<Industry, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Industry> industryList = await _industryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return industryList;
    }

    public async Task<Industry> AddAsync(Industry industry)
    {
        Industry addedIndustry = await _industryRepository.AddAsync(industry);

        return addedIndustry;
    }

    public async Task<Industry> UpdateAsync(Industry industry)
    {
        Industry updatedIndustry = await _industryRepository.UpdateAsync(industry);

        return updatedIndustry;
    }

    public async Task<Industry> DeleteAsync(Industry industry, bool permanent = false)
    {
        Industry deletedIndustry = await _industryRepository.DeleteAsync(industry);

        return deletedIndustry;
    }
}
