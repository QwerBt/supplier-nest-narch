using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class TransactionDetail:Entity<int>
{
    public TransactionDetail()
    {
        Items = new HashSet<Item>();
    }

    public TransactionDetail(int transactionId, Transaction transaction, int quantity, decimal unitPrice, decimal totalPrice, decimal discount, decimal tax, ICollection<Item> ıtems):this()
    {
        TransactionId = transactionId;
        Transaction = transaction;
        Quantity = quantity;
        UnitPrice = unitPrice;
        TotalPrice = totalPrice;
        Discount = discount;
        Tax = tax;
        Items = ıtems;
    }

    public int TransactionId { get; set; } // İşlem Id'si (FK)
    public Transaction Transaction { get; set; } // İlgili işlem bilgisi (FK)

    public int Quantity { get; set; } // Ürün miktarı
    public decimal UnitPrice { get; set; } // Ürün birim fiyatı
    public decimal TotalPrice { get; set; } // Toplam fiyat (Quantity * UnitPrice)
    public decimal Discount { get; set; } // İndirim (varsa)
    public decimal Tax { get; set; } // Vergi (varsa)

    // İlişkili ürün bilgileri

    // Splitting için navigasyonel özellikler
    public TransactionOfferDetail? TransactionOfferDetail { get; set; }
    public TransactionOrderDetail? TransactionOrderDetail { get; set; }
    public TransactionInvoiceDetail? TransactionInvoiceDetail { get; set; }
    public TransactionWaybillDetail? TransactionWaybillDetail { get; set; }

    public virtual ICollection<Item> Items { get; set; }
}



