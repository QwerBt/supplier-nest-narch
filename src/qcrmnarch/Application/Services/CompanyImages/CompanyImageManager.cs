using Application.Features.CompanyImages.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyImages;

public class CompanyImageManager : ICompanyImageService
{
    private readonly ICompanyImageRepository _companyImageRepository;
    private readonly CompanyImageBusinessRules _companyImageBusinessRules;

    public CompanyImageManager(ICompanyImageRepository companyImageRepository, CompanyImageBusinessRules companyImageBusinessRules)
    {
        _companyImageRepository = companyImageRepository;
        _companyImageBusinessRules = companyImageBusinessRules;
    }

    public async Task<CompanyImage?> GetAsync(
        Expression<Func<CompanyImage, bool>> predicate,
        Func<IQueryable<CompanyImage>, IIncludableQueryable<CompanyImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CompanyImage? companyImage = await _companyImageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return companyImage;
    }

    public async Task<IPaginate<CompanyImage>?> GetListAsync(
        Expression<Func<CompanyImage, bool>>? predicate = null,
        Func<IQueryable<CompanyImage>, IOrderedQueryable<CompanyImage>>? orderBy = null,
        Func<IQueryable<CompanyImage>, IIncludableQueryable<CompanyImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CompanyImage> companyImageList = await _companyImageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return companyImageList;
    }

    public async Task<CompanyImage> AddAsync(CompanyImage companyImage)
    {
        CompanyImage addedCompanyImage = await _companyImageRepository.AddAsync(companyImage);

        return addedCompanyImage;
    }

    public async Task<CompanyImage> UpdateAsync(CompanyImage companyImage)
    {
        CompanyImage updatedCompanyImage = await _companyImageRepository.UpdateAsync(companyImage);

        return updatedCompanyImage;
    }

    public async Task<CompanyImage> DeleteAsync(CompanyImage companyImage, bool permanent = false)
    {
        CompanyImage deletedCompanyImage = await _companyImageRepository.DeleteAsync(companyImage);

        return deletedCompanyImage;
    }
}
