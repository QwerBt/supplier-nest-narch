using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProductImage : Entity<Guid>
{
    public int ProductId { get; set; } // Item ile ilişki
    //public Item Item { get; set; }  // Item navigation property

    public string FilePath { get; set; } // Resim dosyasının yolu (dosya sistemi veya URL)
    public string FileName { get; set; } // Dosya adı


 
}
