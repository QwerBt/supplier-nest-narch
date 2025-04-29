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

namespace Application.Features.Uoms.Commands.Update;

public class UpdateUomCommand : IRequest<UpdatedUomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string Description { get; set; }

    public string[] Roles => [Admin, Write, UomsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUoms"];

    public class UpdateUomCommandHandler : IRequestHandler<UpdateUomCommand, UpdatedUomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUomRepository _uomRepository;
        private readonly UomBusinessRules _uomBusinessRules;

        public UpdateUomCommandHandler(IMapper mapper, IUomRepository uomRepository,
                                         UomBusinessRules uomBusinessRules)
        {
            _mapper = mapper;
            _uomRepository = uomRepository;
            _uomBusinessRules = uomBusinessRules;
        }

        public async Task<UpdatedUomResponse> Handle(UpdateUomCommand request, CancellationToken cancellationToken)
        {
            Uom? uom = await _uomRepository.GetAsync(predicate: u => u.Id == request.Id, cancellationToken: cancellationToken);
            await _uomBusinessRules.UomShouldExistWhenSelected(uom);
            uom = _mapper.Map(request, uom);

            await _uomRepository.UpdateAsync(uom!);

            UpdatedUomResponse response = _mapper.Map<UpdatedUomResponse>(uom);
            return response;
        }
    }
}