using Application.Features.Services.Constants;
using Application.Features.Services.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Services.Constants.ServicesOperationClaims;

namespace Application.Features.Services.Queries.GetById;

public class GetByIdServiceQuery : IRequest<GetByIdServiceResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdServiceQueryHandler : IRequestHandler<GetByIdServiceQuery, GetByIdServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;
        private readonly ServiceBusinessRules _serviceBusinessRules;

        public GetByIdServiceQueryHandler(IMapper mapper, IServiceRepository serviceRepository, ServiceBusinessRules serviceBusinessRules)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
            _serviceBusinessRules = serviceBusinessRules;
        }

        public async Task<GetByIdServiceResponse> Handle(GetByIdServiceQuery request, CancellationToken cancellationToken)
        {
            Service? service = await _serviceRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _serviceBusinessRules.ServiceShouldExistWhenSelected(service);

            GetByIdServiceResponse response = _mapper.Map<GetByIdServiceResponse>(service);
            return response;
        }
    }
}