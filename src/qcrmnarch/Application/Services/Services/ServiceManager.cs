using Application.Features.Services.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Services;

public class ServiceManager : IServiceService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly ServiceBusinessRules _serviceBusinessRules;

    public ServiceManager(IServiceRepository serviceRepository, ServiceBusinessRules serviceBusinessRules)
    {
        _serviceRepository = serviceRepository;
        _serviceBusinessRules = serviceBusinessRules;
    }

    public async Task<Service?> GetAsync(
        Expression<Func<Service, bool>> predicate,
        Func<IQueryable<Service>, IIncludableQueryable<Service, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Service? service = await _serviceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return service;
    }

    public async Task<IPaginate<Service>?> GetListAsync(
        Expression<Func<Service, bool>>? predicate = null,
        Func<IQueryable<Service>, IOrderedQueryable<Service>>? orderBy = null,
        Func<IQueryable<Service>, IIncludableQueryable<Service, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Service> serviceList = await _serviceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return serviceList;
    }

    public async Task<Service> AddAsync(Service service)
    {
        Service addedService = await _serviceRepository.AddAsync(service);

        return addedService;
    }

    public async Task<Service> UpdateAsync(Service service)
    {
        Service updatedService = await _serviceRepository.UpdateAsync(service);

        return updatedService;
    }

    public async Task<Service> DeleteAsync(Service service, bool permanent = false)
    {
        Service deletedService = await _serviceRepository.DeleteAsync(service);

        return deletedService;
    }
}
