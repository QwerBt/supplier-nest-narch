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

namespace Application.Features.Services.Commands.Create;

public class CreateServiceCommand : IRequest<CreatedServiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, ServicesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetServices"];

    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, CreatedServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;
        private readonly ServiceBusinessRules _serviceBusinessRules;

        public CreateServiceCommandHandler(IMapper mapper, IServiceRepository serviceRepository,
                                         ServiceBusinessRules serviceBusinessRules)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
            _serviceBusinessRules = serviceBusinessRules;
        }

        public async Task<CreatedServiceResponse> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            Service service = _mapper.Map<Service>(request);

            await _serviceRepository.AddAsync(service);

            CreatedServiceResponse response = _mapper.Map<CreatedServiceResponse>(service);
            return response;
        }
    }
}