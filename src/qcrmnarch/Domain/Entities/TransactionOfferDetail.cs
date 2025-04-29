namespace Domain.Entities;

public class TransactionOfferDetail
{
    public int TransactionDetailId { get; set; } // Foreign Key
    public string AdditionalOfferInfo { get; set; } // Örneğin, teklif notları
    public decimal Discount { get; set; } // Teklife özel indirim

    // TransactionDetail ile ilişki
    public TransactionDetail TransactionDetail { get; set; }
}
