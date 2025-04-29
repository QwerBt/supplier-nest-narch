using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CompanyImage:Entity<Guid>
{
    public int CompanyId { get; set; } // Şirketle ilişki
    //public Company Company { get; set; }

    public string FilePath { get; set; } // Resim dosyasının yolu (dosya sistemi veya URL)
    public string FileName { get; set; } // Dosya adı
    // Navigation property
}