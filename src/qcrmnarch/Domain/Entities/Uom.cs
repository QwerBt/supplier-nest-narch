using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Uom : Entity<int>
{
    public string Name { get; set; } // Birim adı (ör. "Kilogram", "Adet")
    public string Code { get; set; } // Birim kodu (ör. "kg", "pcs")
    public string Description { get; set; } // Birim açıklaması
}
