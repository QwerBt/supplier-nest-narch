using Application.Features.Transactions.Constants;
using Application.Features.Transactions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Transactions.Constants.TransactionsOperationClaims;

namespace Application.Features.Transactions.Queries.GetById;

public class GetByIdTransactionQuery : IRequest<GetByIdTransactionResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTransactionQueryHandler : IRequestHandler<GetByIdTransactionQuery, GetByIdTransactionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;
        private readonly TransactionBusinessRules _transactionBusinessRules;

        public GetByIdTransactionQueryHandler(IMapper mapper, ITransactionRepository transactionRepository, TransactionBusinessRules transactionBusinessRules)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _transactionBusinessRules = transactionBusinessRules;
        }

        public async Task<GetByIdTransactionResponse> Handle(GetByIdTransactionQuery request, CancellationToken cancellationToken)
        {
            Transaction? transaction = await _transactionRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _transactionBusinessRules.TransactionShouldExistWhenSelected(transaction);

            GetByIdTransactionResponse response = _mapper.Map<GetByIdTransactionResponse>(transaction);
            return response;
        }
    }
}