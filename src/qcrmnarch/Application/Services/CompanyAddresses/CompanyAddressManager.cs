using Application.Features.CompanyAddresses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyAddresses;

public class CompanyAddressManager : ICompanyAddressService
{
    private readonly ICompanyAddressRepository _companyAddressRepository;
    private readonly CompanyAddressBusinessRules _companyAddressBusinessRules;

    public CompanyAddressManager(ICompanyAddressRepository companyAddressRepository, CompanyAddressBusinessRules companyAddressBusinessRules)
    {
        _companyAddressRepository = companyAddressRepository;
        _companyAddressBusinessRules = companyAddressBusinessRules;
    }

    public async Task<CompanyAddress?> GetAsync(
        Expression<Func<CompanyAddress, bool>> predicate,
        Func<IQueryable<CompanyAddress>, IIncludableQueryable<CompanyAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CompanyAddress? companyAddress = await _companyAddressRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return companyAddress;
    }

    public async Task<IPaginate<CompanyAddress>?> GetListAsync(
        Expression<Func<CompanyAddress, bool>>? predicate = null,
        Func<IQueryable<CompanyAddress>, IOrderedQueryable<CompanyAddress>>? orderBy = null,
        Func<IQueryable<CompanyAddress>, IIncludableQueryable<CompanyAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CompanyAddress> companyAddressList = await _companyAddressRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return companyAddressList;
    }

    public async Task<CompanyAddress> AddAsync(CompanyAddress companyAddress)
    {
        CompanyAddress addedCompanyAddress = await _companyAddressRepository.AddAsync(companyAddress);

        return addedCompanyAddress;
    }

    public async Task<CompanyAddress> UpdateAsync(CompanyAddress companyAddress)
    {
        CompanyAddress updatedCompanyAddress = await _companyAddressRepository.UpdateAsync(companyAddress);

        return updatedCompanyAddress;
    }

    public async Task<CompanyAddress> DeleteAsync(CompanyAddress companyAddress, bool permanent = false)
    {
        CompanyAddress deletedCompanyAddress = await _companyAddressRepository.DeleteAsync(companyAddress);

        return deletedCompanyAddress;
    }
}
