namespace Domain.Entities;

public class TransactionOrderDetail
{
    public int TransactionDetailId { get; set; } // Foreign Key
    public DateTime ExpectedDeliveryDate { get; set; } // Tahmini teslimat tarihi
    public string ShippingMethod { get; set; } // Kargo yöntemi

    // TransactionDetail ile ilişki
    public TransactionDetail TransactionDetail { get; set; }
}
