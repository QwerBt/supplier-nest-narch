namespace Domain.Entities;

public class TransactionWaybill
{
    public TransactionWaybill()
    {
    }

    public TransactionWaybill(int transactionId, string note, Transaction transaction):this()
    {
        TransactionId = transactionId;
        Note = note;
        Transaction = transaction;
    }

    public int TransactionId { get; set; }
    public string Note { get; set; }
    public Transaction Transaction { get; set; }
}