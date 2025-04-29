using Application.Features.Specifications.Constants;
using Application.Features.Specifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Specifications.Constants.SpecificationsOperationClaims;

namespace Application.Features.Specifications.Queries.GetById;

public class GetByIdSpecificationQuery : IRequest<GetByIdSpecificationResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdSpecificationQueryHandler : IRequestHandler<GetByIdSpecificationQuery, GetByIdSpecificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISpecificationRepository _specificationRepository;
        private readonly SpecificationBusinessRules _specificationBusinessRules;

        public GetByIdSpecificationQueryHandler(IMapper mapper, ISpecificationRepository specificationRepository, SpecificationBusinessRules specificationBusinessRules)
        {
            _mapper = mapper;
            _specificationRepository = specificationRepository;
            _specificationBusinessRules = specificationBusinessRules;
        }

        public async Task<GetByIdSpecificationResponse> Handle(GetByIdSpecificationQuery request, CancellationToken cancellationToken)
        {
            Specification? specification = await _specificationRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _specificationBusinessRules.SpecificationShouldExistWhenSelected(specification);

            GetByIdSpecificationResponse response = _mapper.Map<GetByIdSpecificationResponse>(specification);
            return response;
        }
    }
}