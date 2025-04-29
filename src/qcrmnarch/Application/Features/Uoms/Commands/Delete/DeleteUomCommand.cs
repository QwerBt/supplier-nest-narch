using Application.Features.Uoms.Constants;
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

namespace Application.Features.Uoms.Commands.Delete;

public class DeleteUomCommand : IRequest<DeletedUomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, UomsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUoms"];

    public class DeleteUomCommandHandler : IRequestHandler<DeleteUomCommand, DeletedUomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUomRepository _uomRepository;
        private readonly UomBusinessRules _uomBusinessRules;

        public DeleteUomCommandHandler(IMapper mapper, IUomRepository uomRepository,
                                         UomBusinessRules uomBusinessRules)
        {
            _mapper = mapper;
            _uomRepository = uomRepository;
            _uomBusinessRules = uomBusinessRules;
        }

        public async Task<DeletedUomResponse> Handle(DeleteUomCommand request, CancellationToken cancellationToken)
        {
            Uom? uom = await _uomRepository.GetAsync(predicate: u => u.Id == request.Id, cancellationToken: cancellationToken);
            await _uomBusinessRules.UomShouldExistWhenSelected(uom);

            await _uomRepository.DeleteAsync(uom!);

            DeletedUomResponse response = _mapper.Map<DeletedUomResponse>(uom);
            return response;
        }
    }
}