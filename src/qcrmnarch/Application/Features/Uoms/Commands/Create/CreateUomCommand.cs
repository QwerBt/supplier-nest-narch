using Application.Features.Uoms.Constants;
using Application.Features.Uoms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Uoms.Constants.UomsOperationClaims;

namespace Application.Features.Uoms.Commands.Create;

public class CreateUomCommand : IRequest<CreatedUomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string Description { get; set; }

    public string[] Roles => [Admin, Write, UomsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUoms"];

    public class CreateUomCommandHandler : IRequestHandler<CreateUomCommand, CreatedUomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUomRepository _uomRepository;
        private readonly UomBusinessRules _uomBusinessRules;

        public CreateUomCommandHandler(IMapper mapper, IUomRepository uomRepository,
                                         UomBusinessRules uomBusinessRules)
        {
            _mapper = mapper;
            _uomRepository = uomRepository;
            _uomBusinessRules = uomBusinessRules;
        }

        public async Task<CreatedUomResponse> Handle(CreateUomCommand request, CancellationToken cancellationToken)
        {
            Uom uom = _mapper.Map<Uom>(request);

            await _uomRepository.AddAsync(uom);

            CreatedUomResponse response = _mapper.Map<CreatedUomResponse>(uom);
            return response;
        }
    }
}