using Application.Features.CompanyServices.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyServices;

public class CompanyServiceManager : ICompanyServiceService
{
    private readonly ICompanyServiceRepository _companyServiceRepository;
    private readonly CompanyServiceBusinessRules _companyServiceBusinessRules;

    public CompanyServiceManager(ICompanyServiceRepository companyServiceRepository, CompanyServiceBusinessRules companyServiceBusinessRules)
    {
        _companyServiceRepository = companyServiceRepository;
        _companyServiceBusinessRules = companyServiceBusinessRules;
    }

    public async Task<CompanyService?> GetAsync(
        Expression<Func<CompanyService, bool>> predicate,
        Func<IQueryable<CompanyService>, IIncludableQueryable<CompanyService, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CompanyService? companyService = await _companyServiceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return companyService;
    }

    public async Task<IPaginate<CompanyService>?> GetListAsync(
        Expression<Func<CompanyService, bool>>? predicate = null,
        Func<IQueryable<CompanyService>, IOrderedQueryable<CompanyService>>? orderBy = null,
        Func<IQueryable<CompanyService>, IIncludableQueryable<CompanyService, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CompanyService> companyServiceList = await _companyServiceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return companyServiceList;
    }

    public async Task<CompanyService> AddAsync(CompanyService companyService)
    {
        CompanyService addedCompanyService = await _companyServiceRepository.AddAsync(companyService);

        return addedCompanyService;
    }

    public async Task<CompanyService> UpdateAsync(CompanyService companyService)
    {
        CompanyService updatedCompanyService = await _companyServiceRepository.UpdateAsync(companyService);

        return updatedCompanyService;
    }

    public async Task<CompanyService> DeleteAsync(CompanyService companyService, bool permanent = false)
    {
        CompanyService deletedCompanyService = await _companyServiceRepository.DeleteAsync(companyService);

        return deletedCompanyService;
    }
}
