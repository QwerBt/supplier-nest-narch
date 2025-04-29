using Application.Features.Disciplines.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Disciplines;

public class DisciplineManager : IDisciplineService
{
    private readonly IDisciplineRepository _disciplineRepository;
    private readonly DisciplineBusinessRules _disciplineBusinessRules;

    public DisciplineManager(IDisciplineRepository disciplineRepository, DisciplineBusinessRules disciplineBusinessRules)
    {
        _disciplineRepository = disciplineRepository;
        _disciplineBusinessRules = disciplineBusinessRules;
    }

    public async Task<Discipline?> GetAsync(
        Expression<Func<Discipline, bool>> predicate,
        Func<IQueryable<Discipline>, IIncludableQueryable<Discipline, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Discipline? discipline = await _disciplineRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return discipline;
    }

    public async Task<IPaginate<Discipline>?> GetListAsync(
        Expression<Func<Discipline, bool>>? predicate = null,
        Func<IQueryable<Discipline>, IOrderedQueryable<Discipline>>? orderBy = null,
        Func<IQueryable<Discipline>, IIncludableQueryable<Discipline, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Discipline> disciplineList = await _disciplineRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return disciplineList;
    }

    public async Task<Discipline> AddAsync(Discipline discipline)
    {
        Discipline addedDiscipline = await _disciplineRepository.AddAsync(discipline);

        return addedDiscipline;
    }

    public async Task<Discipline> UpdateAsync(Discipline discipline)
    {
        Discipline updatedDiscipline = await _disciplineRepository.UpdateAsync(discipline);

        return updatedDiscipline;
    }

    public async Task<Discipline> DeleteAsync(Discipline discipline, bool permanent = false)
    {
        Discipline deletedDiscipline = await _disciplineRepository.DeleteAsync(discipline);

        return deletedDiscipline;
    }
}
