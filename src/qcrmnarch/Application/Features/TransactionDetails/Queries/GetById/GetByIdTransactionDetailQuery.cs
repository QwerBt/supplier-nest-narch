using Application.Features.TransactionDetails.Constants;
using Application.Features.TransactionDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.TransactionDetails.Constants.TransactionDetailsOperationClaims;

namespace Application.Features.TransactionDetails.Queries.GetById;

public class GetByIdTransactionDetailQuery : IRequest<GetByIdTransactionDetailResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTransactionDetailQueryHandler : IRequestHandler<GetByIdTransactionDetailQuery, GetByIdTransactionDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionDetailRepository _transactionDetailRepository;
        private readonly TransactionDetailBusinessRules _transactionDetailBusinessRules;

        public GetByIdTransactionDetailQueryHandler(IMapper mapper, ITransactionDetailRepository transactionDetailRepository, TransactionDetailBusinessRules transactionDetailBusinessRules)
        {
            _mapper = mapper;
            _transactionDetailRepository = transactionDetailRepository;
            _transactionDetailBusinessRules = transactionDetailBusinessRules;
        }

        public async Task<GetByIdTransactionDetailResponse> Handle(GetByIdTransactionDetailQuery request, CancellationToken cancellationToken)
        {
            TransactionDetail? transactionDetail = await _transactionDetailRepository.GetAsync(predicate: td => td.Id == request.Id, cancellationToken: cancellationToken);
            await _transactionDetailBusinessRules.TransactionDetailShouldExistWhenSelected(transactionDetail);

            GetByIdTransactionDetailResponse response = _mapper.Map<GetByIdTransactionDetailResponse>(transactionDetail);
            return response;
        }
    }
}