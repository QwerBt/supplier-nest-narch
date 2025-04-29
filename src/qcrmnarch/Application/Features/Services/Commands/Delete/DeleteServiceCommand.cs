using Application.Features.Services.Constants;
using Application.Features.Services.Constants;
using Application.Features.Services.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Services.Constants.ServicesOperationClaims;

namespace Application.Features.Services.Commands.Delete;

public class DeleteServiceCommand : IRequest<DeletedServiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, ServicesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetServices"];

    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, DeletedServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;
        private readonly ServiceBusinessRules _serviceBusinessRules;

        public DeleteServiceCommandHandler(IMapper mapper, IServiceRepository serviceRepository,
                                         ServiceBusinessRules serviceBusinessRules)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
            _serviceBusinessRules = serviceBusinessRules;
        }

        public async Task<DeletedServiceResponse> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            Service? service = await _serviceRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _serviceBusinessRules.ServiceShouldExistWhenSelected(service);

            await _serviceRepository.DeleteAsync(service!);

            DeletedServiceResponse response = _mapper.Map<DeletedServiceResponse>(service);
            return response;
        }
    }
}