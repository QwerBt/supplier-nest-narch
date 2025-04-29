using Application.Features.Transactions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Transactions.Constants.TransactionsOperationClaims;

namespace Application.Features.Transactions.Queries.GetList;

public class GetListTransactionQuery : IRequest<GetListResponse<GetListTransactionListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTransactions({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTransactions";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTransactionQueryHandler : IRequestHandler<GetListTransactionQuery, GetListResponse<GetListTransactionListItemDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetListTransactionQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTransactionListItemDto>> Handle(GetListTransactionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Transaction> transactions = await _transactionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTransactionListItemDto> response = _mapper.Map<GetListResponse<GetListTransactionListItemDto>>(transactions);
            return response;
        }
    }
}