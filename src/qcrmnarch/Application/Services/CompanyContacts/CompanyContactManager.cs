using Application.Features.CompanyContacts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyContacts;

public class CompanyContactManager : ICompanyContactService
{
    private readonly ICompanyContactRepository _companyContactRepository;
    private readonly CompanyContactBusinessRules _companyContactBusinessRules;

    public CompanyContactManager(ICompanyContactRepository companyContactRepository, CompanyContactBusinessRules companyContactBusinessRules)
    {
        _companyContactRepository = companyContactRepository;
        _companyContactBusinessRules = companyContactBusinessRules;
    }

    public async Task<CompanyContact?> GetAsync(
        Expression<Func<CompanyContact, bool>> predicate,
        Func<IQueryable<CompanyContact>, IIncludableQueryable<CompanyContact, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CompanyContact? companyContact = await _companyContactRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return companyContact;
    }

    public async Task<IPaginate<CompanyContact>?> GetListAsync(
        Expression<Func<CompanyContact, bool>>? predicate = null,
        Func<IQueryable<CompanyContact>, IOrderedQueryable<CompanyContact>>? orderBy = null,
        Func<IQueryable<CompanyContact>, IIncludableQueryable<CompanyContact, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CompanyContact> companyContactList = await _companyContactRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return companyContactList;
    }

    public async Task<CompanyContact> AddAsync(CompanyContact companyContact)
    {
        CompanyContact addedCompanyContact = await _companyContactRepository.AddAsync(companyContact);

        return addedCompanyContact;
    }

    public async Task<CompanyContact> UpdateAsync(CompanyContact companyContact)
    {
        CompanyContact updatedCompanyContact = await _companyContactRepository.UpdateAsync(companyContact);

        return updatedCompanyContact;
    }

    public async Task<CompanyContact> DeleteAsync(CompanyContact companyContact, bool permanent = false)
    {
        CompanyContact deletedCompanyContact = await _companyContactRepository.DeleteAsync(companyContact);

        return deletedCompanyContact;
    }
}
