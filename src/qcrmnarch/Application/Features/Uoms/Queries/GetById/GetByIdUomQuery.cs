using Application.Features.Uoms.Constants;
using Application.Features.Uoms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Uoms.Constants.UomsOperationClaims;

namespace Application.Features.Uoms.Queries.GetById;

public class GetByIdUomQuery : IRequest<GetByIdUomResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdUomQueryHandler : IRequestHandler<GetByIdUomQuery, GetByIdUomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUomRepository _uomRepository;
        private readonly UomBusinessRules _uomBusinessRules;

        public GetByIdUomQueryHandler(IMapper mapper, IUomRepository uomRepository, UomBusinessRules uomBusinessRules)
        {
            _mapper = mapper;
            _uomRepository = uomRepository;
            _uomBusinessRules = uomBusinessRules;
        }

        public async Task<GetByIdUomResponse> Handle(GetByIdUomQuery request, CancellationToken cancellationToken)
        {
            Uom? uom = await _uomRepository.GetAsync(predicate: u => u.Id == request.Id, cancellationToken: cancellationToken);
            await _uomBusinessRules.UomShouldExistWhenSelected(uom);

            GetByIdUomResponse response = _mapper.Map<GetByIdUomResponse>(uom);
            return response;
        }
    }
}