using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;

namespace Domain.Entities;

public class Item:Entity<int>
{
    public Item()
    {
        ItemUoms=new HashSet<ItemUom>();
    }

    public Item(string code, string name,  
        string description, decimal unitPrice,  ICollection<ItemUom> itemUoms, ICollection<ItemSpecification> itemSpecifications)
 
    {
        Code = code;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
        ItemUoms = itemUoms;
        ItemSpecifications = itemSpecifications;
    }

    public string Code { get; set; } // Ürün kodu
    public string Name { get; set; } // Ürün adı
    public string Description { get; set; } // Ürün açıklaması
    public decimal UnitPrice { get; set; } // Birim fiyat

 
    public int ProductId { get; set; }
    public virtual Product? Product { get; set; }

    public virtual ICollection<ItemUom> ItemUoms { get; set; }
    public virtual ICollection<ItemSpecification>? ItemSpecifications { get; set; }
 

}
