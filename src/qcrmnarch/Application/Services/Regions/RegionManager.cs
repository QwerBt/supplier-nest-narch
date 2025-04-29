using Application.Features.Regions.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Regions;

public class RegionManager : IRegionService
{
    private readonly IRegionRepository _regionRepository;
    private readonly RegionBusinessRules _regionBusinessRules;

    public RegionManager(IRegionRepository regionRepository, RegionBusinessRules regionBusinessRules)
    {
        _regionRepository = regionRepository;
        _regionBusinessRules = regionBusinessRules;
    }

    public async Task<Region?> GetAsync(
        Expression<Func<Region, bool>> predicate,
        Func<IQueryable<Region>, IIncludableQueryable<Region, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Region? region = await _regionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return region;
    }

    public async Task<IPaginate<Region>?> GetListAsync(
        Expression<Func<Region, bool>>? predicate = null,
        Func<IQueryable<Region>, IOrderedQueryable<Region>>? orderBy = null,
        Func<IQueryable<Region>, IIncludableQueryable<Region, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Region> regionList = await _regionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return regionList;
    }

    public async Task<Region> AddAsync(Region region)
    {
        Region addedRegion = await _regionRepository.AddAsync(region);

        return addedRegion;
    }

    public async Task<Region> UpdateAsync(Region region)
    {
        Region updatedRegion = await _regionRepository.UpdateAsync(region);

        return updatedRegion;
    }

    public async Task<Region> DeleteAsync(Region region, bool permanent = false)
    {
        Region deletedRegion = await _regionRepository.DeleteAsync(region);

        return deletedRegion;
    }
}
