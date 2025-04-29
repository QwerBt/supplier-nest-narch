using Application.Features.CompanyBrands.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyBrands;

public class CompanyBrandManager : ICompanyBrandService
{
    private readonly ICompanyBrandRepository _companyBrandRepository;
    private readonly CompanyBrandBusinessRules _companyBrandBusinessRules;

    public CompanyBrandManager(ICompanyBrandRepository companyBrandRepository, CompanyBrandBusinessRules companyBrandBusinessRules)
    {
        _companyBrandRepository = companyBrandRepository;
        _companyBrandBusinessRules = companyBrandBusinessRules;
    }

    public async Task<CompanyBrand?> GetAsync(
        Expression<Func<CompanyBrand, bool>> predicate,
        Func<IQueryable<CompanyBrand>, IIncludableQueryable<CompanyBrand, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CompanyBrand? companyBrand = await _companyBrandRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return companyBrand;
    }

    public async Task<IPaginate<CompanyBrand>?> GetListAsync(
        Expression<Func<CompanyBrand, bool>>? predicate = null,
        Func<IQueryable<CompanyBrand>, IOrderedQueryable<CompanyBrand>>? orderBy = null,
        Func<IQueryable<CompanyBrand>, IIncludableQueryable<CompanyBrand, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CompanyBrand> companyBrandList = await _companyBrandRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return companyBrandList;
    }

    public async Task<CompanyBrand> AddAsync(CompanyBrand companyBrand)
    {
        CompanyBrand addedCompanyBrand = await _companyBrandRepository.AddAsync(companyBrand);

        return addedCompanyBrand;
    }

    public async Task<CompanyBrand> UpdateAsync(CompanyBrand companyBrand)
    {
        CompanyBrand updatedCompanyBrand = await _companyBrandRepository.UpdateAsync(companyBrand);

        return updatedCompanyBrand;
    }

    public async Task<CompanyBrand> DeleteAsync(CompanyBrand companyBrand, bool permanent = false)
    {
        CompanyBrand deletedCompanyBrand = await _companyBrandRepository.DeleteAsync(companyBrand);

        return deletedCompanyBrand;
    }
}
