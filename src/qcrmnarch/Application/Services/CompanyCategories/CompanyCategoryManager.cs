using Application.Features.CompanyCategories.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyCategories;

public class CompanyCategoryManager : ICompanyCategoryService
{
    private readonly ICompanyCategoryRepository _companyCategoryRepository;
    private readonly CompanyCategoryBusinessRules _companyCategoryBusinessRules;

    public CompanyCategoryManager(ICompanyCategoryRepository companyCategoryRepository, CompanyCategoryBusinessRules companyCategoryBusinessRules)
    {
        _companyCategoryRepository = companyCategoryRepository;
        _companyCategoryBusinessRules = companyCategoryBusinessRules;
    }

    public async Task<CompanyCategory?> GetAsync(
        Expression<Func<CompanyCategory, bool>> predicate,
        Func<IQueryable<CompanyCategory>, IIncludableQueryable<CompanyCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CompanyCategory? companyCategory = await _companyCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return companyCategory;
    }

    public async Task<IPaginate<CompanyCategory>?> GetListAsync(
        Expression<Func<CompanyCategory, bool>>? predicate = null,
        Func<IQueryable<CompanyCategory>, IOrderedQueryable<CompanyCategory>>? orderBy = null,
        Func<IQueryable<CompanyCategory>, IIncludableQueryable<CompanyCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CompanyCategory> companyCategoryList = await _companyCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return companyCategoryList;
    }

    public async Task<CompanyCategory> AddAsync(CompanyCategory companyCategory)
    {
        CompanyCategory addedCompanyCategory = await _companyCategoryRepository.AddAsync(companyCategory);

        return addedCompanyCategory;
    }

    public async Task<CompanyCategory> UpdateAsync(CompanyCategory companyCategory)
    {
        CompanyCategory updatedCompanyCategory = await _companyCategoryRepository.UpdateAsync(companyCategory);

        return updatedCompanyCategory;
    }

    public async Task<CompanyCategory> DeleteAsync(CompanyCategory companyCategory, bool permanent = false)
    {
        CompanyCategory deletedCompanyCategory = await _companyCategoryRepository.DeleteAsync(companyCategory);

        return deletedCompanyCategory;
    }
}
