using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class ItemUom : Entity<int>
{
    public ItemUom()
    {
    }

    public ItemUom(int ıtemId, Item ıtem, int uomId, Uom uom, decimal conversionRate):this()
    {
        ItemId = ıtemId;
        Item = ıtem;
        UomId = uomId;
        Uom = uom;
        ConversionRate = conversionRate;
    }

    public int ItemId { get; set; } // Foreign Key
    public Item Item { get; set; } // Navigation Property

    public int UomId { get; set; } // Foreign Key
    public Uom Uom { get; set; } // Navigation Property

    public decimal ConversionRate { get; set; } // Dönüşüm oranı (ör. 1 Kutu = 12 Adet)
}