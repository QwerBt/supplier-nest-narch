using Application.Features.CompanyUsers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyUsers;

public class CompanyUserManager : ICompanyUserService
{
    private readonly ICompanyUserRepository _companyUserRepository;
    private readonly CompanyUserBusinessRules _companyUserBusinessRules;

    public CompanyUserManager(ICompanyUserRepository companyUserRepository, CompanyUserBusinessRules companyUserBusinessRules)
    {
        _companyUserRepository = companyUserRepository;
        _companyUserBusinessRules = companyUserBusinessRules;
    }

    public async Task<CompanyUser?> GetAsync(
        Expression<Func<CompanyUser, bool>> predicate,
        Func<IQueryable<CompanyUser>, IIncludableQueryable<CompanyUser, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CompanyUser? companyUser = await _companyUserRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return companyUser;
    }

    public async Task<IPaginate<CompanyUser>?> GetListAsync(
        Expression<Func<CompanyUser, bool>>? predicate = null,
        Func<IQueryable<CompanyUser>, IOrderedQueryable<CompanyUser>>? orderBy = null,
        Func<IQueryable<CompanyUser>, IIncludableQueryable<CompanyUser, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CompanyUser> companyUserList = await _companyUserRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return companyUserList;
    }

    public async Task<CompanyUser> AddAsync(CompanyUser companyUser)
    {
        CompanyUser addedCompanyUser = await _companyUserRepository.AddAsync(companyUser);

        return addedCompanyUser;
    }

    public async Task<CompanyUser> UpdateAsync(CompanyUser companyUser)
    {
        CompanyUser updatedCompanyUser = await _companyUserRepository.UpdateAsync(companyUser);

        return updatedCompanyUser;
    }

    public async Task<CompanyUser> DeleteAsync(CompanyUser companyUser, bool permanent = false)
    {
        CompanyUser deletedCompanyUser = await _companyUserRepository.DeleteAsync(companyUser);

        return deletedCompanyUser;
    }
}
