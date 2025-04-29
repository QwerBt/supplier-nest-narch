using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;

namespace Domain.Entities;

public class Transaction:Entity<int>
{
    public Transaction()
    {
        TransactionDetails = new HashSet<TransactionDetail>();

    }

    public Transaction(int companyId, Company company, TransactionTypeEnum transactionType, DateTime transactionDate, string status, decimal totalAmount, TransactionOffer? transactionOffer, TransactionOrder? transactionOrder, TransactionInvoice? transactionInvoice, TransactionWaybill? transactionWaybill, ICollection<TransactionDetail> transactionDetails):this()
    {
        CompanyId = companyId;
        Company = company;
        TransactionType = transactionType;
        TransactionDate = transactionDate;
        Status = status;
        TotalAmount = totalAmount;
        TransactionOffer = transactionOffer;
        TransactionOrder = transactionOrder;
        TransactionInvoice = transactionInvoice;
        TransactionWaybill = transactionWaybill;
        TransactionDetails = transactionDetails;
    }

    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public TransactionTypeEnum TransactionType { get; set; } // Sipariş, fatura, irsaliye türünü belirtir (enum)
    public DateTime TransactionDate { get; set; }
    public string Status { get; set; }
    public decimal TotalAmount { get; set; }

    // Splitting için navigasyonel özellikler
    public TransactionOffer? TransactionOffer { get; set; }
    public TransactionOrder? TransactionOrder { get; set; }
    public TransactionInvoice? TransactionInvoice { get; set; }
    public TransactionWaybill? TransactionWaybill { get; set; }


    public ICollection<TransactionDetail> TransactionDetails { get; set; }
}


