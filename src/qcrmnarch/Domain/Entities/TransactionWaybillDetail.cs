namespace Domain.Entities;

public class TransactionWaybillDetail
{
    public int TransactionDetailId { get; set; } // Foreign Key
    public string TaxCode { get; set; } // Vergi kodu
    public decimal TaxAmount { get; set; } // Vergi tutarı
    public DateTime DueDate { get; set; } // Ödeme vadesi

    // TransactionDetail ile ilişki
    public TransactionDetail TransactionDetail { get; set; }
}