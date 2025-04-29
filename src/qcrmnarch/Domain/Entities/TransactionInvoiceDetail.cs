namespace Domain.Entities;

public class TransactionInvoiceDetail
{
    public int TransactionDetailId { get; set; } // Foreign Key
    public string TaxCode { get; set; } // Vergi kodu
    public decimal TaxAmount { get; set; } // Vergi tutarı
    public DateTime PaymentDueDate { get; set; } // Ödeme vadesi

    // TransactionDetail ile ilişki
    public TransactionDetail TransactionDetail { get; set; }
}
