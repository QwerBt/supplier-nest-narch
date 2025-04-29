using Application.Features.Transactions.Constants;
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

namespace Application.Features.Transactions.Commands.Delete;

public class DeleteTransactionCommand : IRequest<DeletedTransactionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, TransactionsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTransactions"];

    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, DeletedTransactionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;
        private readonly TransactionBusinessRules _transactionBusinessRules;

        public DeleteTransactionCommandHandler(IMapper mapper, ITransactionRepository transactionRepository,
                                         TransactionBusinessRules transactionBusinessRules)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _transactionBusinessRules = transactionBusinessRules;
        }

        public async Task<DeletedTransactionResponse> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            Transaction? transaction = await _transactionRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _transactionBusinessRules.TransactionShouldExistWhenSelected(transaction);

            await _transactionRepository.DeleteAsync(transaction!);

            DeletedTransactionResponse response = _mapper.Map<DeletedTransactionResponse>(transaction);
            return response;
        }
    }
}