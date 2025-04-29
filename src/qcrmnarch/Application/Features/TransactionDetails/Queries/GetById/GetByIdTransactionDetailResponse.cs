using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.TransactionDetails.Queries.GetById;

public class GetByIdTransactionDetailResponse : IResponse
{
    public int Id { get; set; }
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; }
    public TransactionOfferDetail? OfferDetail { get; set; }
    public TransactionOrderDetail? TransactionOrderDetail { get; set; }
    public TransactionInvoiceDetail? TransactionInvoiceDetail { get; set; }
    public TransactionWaybillDetail? TransactionWaybillDetail { get; set; }
}