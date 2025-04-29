namespace Domain.Entities;

public class TransactionOffer
{
    public TransactionOffer()
    {
    }

    public TransactionOffer(int transactionId, string specialOfferNote, Transaction transaction):this()
    {
        TransactionId = transactionId;
        SpecialOfferNote = specialOfferNote;
        Transaction = transaction;
    }   

    public int TransactionId { get; set; }
    public string SpecialOfferNote { get; set; }
    public Transaction Transaction { get; set; }
}