namespace Domain.Entities;

public class TransactionOrder
{
    public TransactionOrder()
    {
    }

    public TransactionOrder(int transactionId, DateTime orderDate, Transaction transaction):this()
    {
        TransactionId = transactionId;
        OrderDate = orderDate;
        Transaction = transaction;
    }

    public int TransactionId { get; set; }
    public DateTime OrderDate { get; set; }
    public Transaction Transaction { get; set; }
}