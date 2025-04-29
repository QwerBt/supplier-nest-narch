using Application.Features.SpecificationValues.Constants;
using Application.Features.SpecificationValues.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.SpecificationValues.Constants.SpecificationValuesOperationClaims;

namespace Application.Features.SpecificationValues.Queries.GetById;

public class GetByIdSpecificationValueQuery : IRequest<GetByIdSpecificationValueResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdSpecificationValueQueryHandler : IRequestHandler<GetByIdSpecificationValueQuery, GetByIdSpecificationValueResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISpecificationValueRepository _specificationValueRepository;
        private readonly SpecificationValueBusinessRules _specificationValueBusinessRules;

        public GetByIdSpecificationValueQueryHandler(IMapper mapper, ISpecificationValueRepository specificationValueRepository, SpecificationValueBusinessRules specificationValueBusinessRules)
        {
            _mapper = mapper;
            _specificationValueRepository = specificationValueRepository;
            _specificationValueBusinessRules = specificationValueBusinessRules;
        }

        public async Task<GetByIdSpecificationValueResponse> Handle(GetByIdSpecificationValueQuery request, CancellationToken cancellationToken)
        {
            SpecificationValue? specificationValue = await _specificationValueRepository.GetAsync(predicate: sv => sv.Id == request.Id, cancellationToken: cancellationToken);
            await _specificationValueBusinessRules.SpecificationValueShouldExistWhenSelected(specificationValue);

            GetByIdSpecificationValueResponse response = _mapper.Map<GetByIdSpecificationValueResponse>(specificationValue);
            return response;
        }
    }
}