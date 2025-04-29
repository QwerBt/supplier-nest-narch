using Application.Features.TransactionDetails.Constants;
using Application.Features.TransactionDetails.Constants;
using Application.Features.TransactionDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.TransactionDetails.Constants.TransactionDetailsOperationClaims;

namespace Application.Features.TransactionDetails.Commands.Delete;

public class DeleteTransactionDetailCommand : IRequest<DeletedTransactionDetailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, TransactionDetailsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTransactionDetails"];

    public class DeleteTransactionDetailCommandHandler : IRequestHandler<DeleteTransactionDetailCommand, DeletedTransactionDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionDetailRepository _transactionDetailRepository;
        private readonly TransactionDetailBusinessRules _transactionDetailBusinessRules;

        public DeleteTransactionDetailCommandHandler(IMapper mapper, ITransactionDetailRepository transactionDetailRepository,
                                         TransactionDetailBusinessRules transactionDetailBusinessRules)
        {
            _mapper = mapper;
            _transactionDetailRepository = transactionDetailRepository;
            _transactionDetailBusinessRules = transactionDetailBusinessRules;
        }

        public async Task<DeletedTransactionDetailResponse> Handle(DeleteTransactionDetailCommand request, CancellationToken cancellationToken)
        {
            TransactionDetail? transactionDetail = await _transactionDetailRepository.GetAsync(predicate: td => td.Id == request.Id, cancellationToken: cancellationToken);
            await _transactionDetailBusinessRules.TransactionDetailShouldExistWhenSelected(transactionDetail);

            await _transactionDetailRepository.DeleteAsync(transactionDetail!);

            DeletedTransactionDetailResponse response = _mapper.Map<DeletedTransactionDetailResponse>(transactionDetail);
            return response;
        }
    }
}