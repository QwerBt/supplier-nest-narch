namespace Domain.Entities;

public class TransactionInvoice
{
    public TransactionInvoice()
    {
    }

    public TransactionInvoice(int transactionId, string ınvoiceNumber, DateTime ınvoiceDate, Transaction transaction):this()
    {
        TransactionId = transactionId;
        InvoiceNumber = ınvoiceNumber;
        InvoiceDate = ınvoiceDate;
        Transaction = transaction;
    }

    public int TransactionId { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public Transaction Transaction { get; set; }
}   