using Domain.Entities;
using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Transactions.Commands.Update;

public class UpdatedTransactionResponse : IResponse
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Status { get; set; }
    public decimal TotalAmount { get; set; }
    public TransactionOffer? TransactionOffer { get; set; }
    public TransactionOrder? TransactionOrder { get; set; }
    public TransactionInvoice? TransactionInvoice { get; set; }
    public TransactionWaybill? TransactionWaybill { get; set; }
}