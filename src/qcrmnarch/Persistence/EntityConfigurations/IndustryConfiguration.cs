using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class IndustryConfiguration : IEntityTypeConfiguration<Industry>
{
    public void Configure(EntityTypeBuilder<Industry> builder)
    {
        builder.ToTable("Industries").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.Name).HasColumnName("Name").IsRequired();
        builder.Property(i => i.ParentIndustryId).HasColumnName("ParentIndustryId");
        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(i => i.SubIndustries)
            .WithOne(i => i.ParentIndustry)
            .HasForeignKey(i => i.ParentIndustryId) // Foreign Key'i burada belirtiyoruz
            .OnDelete(DeleteBehavior.Restrict); 

        builder.HasData(_seedsIndustry);
        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }

    private IEnumerable<Industry> _seedsIndustry
    {
        get
        {
            var industries = new List<(int Id, string Name,int? ParentIndustry)>
            {
 

           (1, "Havacýlýk ve Savunma", null ),
           (2, "Tarým ve Ormancýlýk", null),
           (3, "Otomotiv", null),
           (4, "Ýþ Hizmetleri", null),
           (5, "Kimyasallar", null),
           (6, "Yapý", null),
           (7, "Daðýtým, Toptan, Perakende", null),
           (8, "Eðitim", null),
           (9, "Elektrik Ekipmanlarý", null),
           (10, "Elektronik", null),
           (11, "Mühendislik ve Teknik Hizmetler", null),
           (12, "Gýda, Ýçecek, Tütün", null),
           (13, "Hükümet ve Askeriye", null),
           (14, "Makineler", null),
           (15, "Üretim (belirtilmemiþ)", null),
           (16, "Týbbi ve Saðlýk", null),
           (17, "Metaller - Ham, Þekillendirilmiþ, Üretilmiþ", null),
           (18, "Madencilik, Petrol ve Gaz, Taþ Ocaðý", null),
           (19, "Diðer", null),
           (20, "Kaðýt, Kaðýt Ürünleri ve Baský", null),
           (21, "Plastikler ve Kauçuk", null),
           (22, "Tekstil, Giyim, Deri", null),
           (23, "Taþýmacýlýk ve Lojistik", null),
           (24, "Kamu Hizmetleri ve Telekomünikasyon", null),
            };
            foreach (var ind in industries)
            {
                yield return new Industry
                {
                    Id = ind.Id,
                    Name = ind.Name,
                    ParentIndustryId = ind.ParentIndustry

                };
            }

        }
    }



}