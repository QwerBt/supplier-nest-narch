using Application.Features.Transactions.Constants;
using Application.Features.Transactions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Transactions.Constants.TransactionsOperationClaims;
using Domain.Enums;

namespace Application.Features.Transactions.Commands.Update;

public class UpdateTransactionCommand : IRequest<UpdatedTransactionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required int CompanyId { get; set; }
    public required Company Company { get; set; }
    public required TransactionTypeEnum TransactionType { get; set; }
    public required DateTime TransactionDate { get; set; }
    public required string Status { get; set; }
    public required decimal TotalAmount { get; set; }
    public TransactionOffer? TransactionOffer { get; set; }
    public TransactionOrder? TransactionOrder { get; set; }
    public TransactionInvoice? TransactionInvoice { get; set; }
    public TransactionWaybill? TransactionWaybill { get; set; }

    public string[] Roles => [Admin, Write, TransactionsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTransactions"];

    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, UpdatedTransactionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;
        private readonly TransactionBusinessRules _transactionBusinessRules;

        public UpdateTransactionCommandHandler(IMapper mapper, ITransactionRepository transactionRepository,
                                         TransactionBusinessRules transactionBusinessRules)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _transactionBusinessRules = transactionBusinessRules;
        }

        public async Task<UpdatedTransactionResponse> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            Transaction? transaction = await _transactionRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _transactionBusinessRules.TransactionShouldExistWhenSelected(transaction);
            transaction = _mapper.Map(request, transaction);

            await _transactionRepository.UpdateAsync(transaction!);

            UpdatedTransactionResponse response = _mapper.Map<UpdatedTransactionResponse>(transaction);
            return response;
        }
    }
}