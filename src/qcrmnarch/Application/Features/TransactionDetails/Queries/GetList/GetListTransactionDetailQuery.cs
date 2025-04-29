using Application.Features.TransactionDetails.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.TransactionDetails.Constants.TransactionDetailsOperationClaims;

namespace Application.Features.TransactionDetails.Queries.GetList;

public class GetListTransactionDetailQuery : IRequest<GetListResponse<GetListTransactionDetailListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTransactionDetails({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTransactionDetails";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTransactionDetailQueryHandler : IRequestHandler<GetListTransactionDetailQuery, GetListResponse<GetListTransactionDetailListItemDto>>
    {
        private readonly ITransactionDetailRepository _transactionDetailRepository;
        private readonly IMapper _mapper;

        public GetListTransactionDetailQueryHandler(ITransactionDetailRepository transactionDetailRepository, IMapper mapper)
        {
            _transactionDetailRepository = transactionDetailRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTransactionDetailListItemDto>> Handle(GetListTransactionDetailQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TransactionDetail> transactionDetails = await _transactionDetailRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTransactionDetailListItemDto> response = _mapper.Map<GetListResponse<GetListTransactionDetailListItemDto>>(transactionDetails);
            return response;
        }
    }
}