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

namespace Application.Features.TransactionDetails.Commands.Update;

public class UpdateTransactionDetailCommand : IRequest<UpdatedTransactionDetailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required int TransactionId { get; set; }
    public required Transaction Transaction { get; set; }
    public required int Quantity { get; set; }
    public required decimal UnitPrice { get; set; }
    public required decimal TotalPrice { get; set; }
    public required decimal Discount { get; set; }
    public required decimal Tax { get; set; }
    public TransactionOfferDetail? OfferDetail { get; set; }
    public TransactionOrderDetail? TransactionOrderDetail { get; set; }
    public TransactionInvoiceDetail? TransactionInvoiceDetail { get; set; }
    public TransactionWaybillDetail? TransactionWaybillDetail { get; set; }

    public string[] Roles => [Admin, Write, TransactionDetailsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTransactionDetails"];

    public class UpdateTransactionDetailCommandHandler : IRequestHandler<UpdateTransactionDetailCommand, UpdatedTransactionDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionDetailRepository _transactionDetailRepository;
        private readonly TransactionDetailBusinessRules _transactionDetailBusinessRules;

        public UpdateTransactionDetailCommandHandler(IMapper mapper, ITransactionDetailRepository transactionDetailRepository,
                                         TransactionDetailBusinessRules transactionDetailBusinessRules)
        {
            _mapper = mapper;
            _transactionDetailRepository = transactionDetailRepository;
            _transactionDetailBusinessRules = transactionDetailBusinessRules;
        }

        public async Task<UpdatedTransactionDetailResponse> Handle(UpdateTransactionDetailCommand request, CancellationToken cancellationToken)
        {
            TransactionDetail? transactionDetail = await _transactionDetailRepository.GetAsync(predicate: td => td.Id == request.Id, cancellationToken: cancellationToken);
            await _transactionDetailBusinessRules.TransactionDetailShouldExistWhenSelected(transactionDetail);
            transactionDetail = _mapper.Map(request, transactionDetail);

            await _transactionDetailRepository.UpdateAsync(transactionDetail!);

            UpdatedTransactionDetailResponse response = _mapper.Map<UpdatedTransactionDetailResponse>(transactionDetail);
            return response;
        }
    }
}