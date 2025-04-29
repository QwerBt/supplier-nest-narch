using Application.Features.Uoms.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Uoms;

public class UomManager : IUomService
{
    private readonly IUomRepository _uomRepository;
    private readonly UomBusinessRules _uomBusinessRules;

    public UomManager(IUomRepository uomRepository, UomBusinessRules uomBusinessRules)
    {
        _uomRepository = uomRepository;
        _uomBusinessRules = uomBusinessRules;
    }

    public async Task<Uom?> GetAsync(
        Expression<Func<Uom, bool>> predicate,
        Func<IQueryable<Uom>, IIncludableQueryable<Uom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Uom? uom = await _uomRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return uom;
    }

    public async Task<IPaginate<Uom>?> GetListAsync(
        Expression<Func<Uom, bool>>? predicate = null,
        Func<IQueryable<Uom>, IOrderedQueryable<Uom>>? orderBy = null,
        Func<IQueryable<Uom>, IIncludableQueryable<Uom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Uom> uomList = await _uomRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return uomList;
    }

    public async Task<Uom> AddAsync(Uom uom)
    {
        Uom addedUom = await _uomRepository.AddAsync(uom);

        return addedUom;
    }

    public async Task<Uom> UpdateAsync(Uom uom)
    {
        Uom updatedUom = await _uomRepository.UpdateAsync(uom);

        return updatedUom;
    }

    public async Task<Uom> DeleteAsync(Uom uom, bool permanent = false)
    {
        Uom deletedUom = await _uomRepository.DeleteAsync(uom);

        return deletedUom;
    }
}
