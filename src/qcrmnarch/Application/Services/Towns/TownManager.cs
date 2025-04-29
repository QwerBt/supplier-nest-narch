using Application.Features.Towns.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Towns;

public class TownManager : ITownService
{
    private readonly ITownRepository _townRepository;
    private readonly TownBusinessRules _townBusinessRules;

    public TownManager(ITownRepository townRepository, TownBusinessRules townBusinessRules)
    {
        _townRepository = townRepository;
        _townBusinessRules = townBusinessRules;
    }

    public async Task<Town?> GetAsync(
        Expression<Func<Town, bool>> predicate,
        Func<IQueryable<Town>, IIncludableQueryable<Town, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Town? town = await _townRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return town;
    }

    public async Task<IPaginate<Town>?> GetListAsync(
        Expression<Func<Town, bool>>? predicate = null,
        Func<IQueryable<Town>, IOrderedQueryable<Town>>? orderBy = null,
        Func<IQueryable<Town>, IIncludableQueryable<Town, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Town> townList = await _townRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return townList;
    }

    public async Task<Town> AddAsync(Town town)
    {
        Town addedTown = await _townRepository.AddAsync(town);

        return addedTown;
    }

    public async Task<Town> UpdateAsync(Town town)
    {
        Town updatedTown = await _townRepository.UpdateAsync(town);

        return updatedTown;
    }

    public async Task<Town> DeleteAsync(Town town, bool permanent = false)
    {
        Town deletedTown = await _townRepository.DeleteAsync(town);

        return deletedTown;
    }
}
