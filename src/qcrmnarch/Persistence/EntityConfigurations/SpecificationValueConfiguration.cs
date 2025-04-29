using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SpecificationValueConfiguration : IEntityTypeConfiguration<SpecificationValue>
{
    public void Configure(EntityTypeBuilder<SpecificationValue> builder)
    {
        builder.ToTable("SpecificationValues").HasKey(sv => sv.Id);

        builder.Property(sv => sv.Id).HasColumnName("Id").IsRequired();
        builder.Property(sv => sv.Name).HasColumnName("Name").IsRequired();
        builder.Property(sv => sv.SpecificationId).HasColumnName("SpecificationId").IsRequired();
        builder.Property(sv => sv.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sv => sv.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sv => sv.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(s => s.Specification)
        .WithMany(sv => sv.SpecificationValues)
        .HasForeignKey(s => s.SpecificationId)
        .OnDelete(DeleteBehavior.Restrict);

 

        builder.HasQueryFilter(sv => !sv.DeletedDate.HasValue);
        builder.HasData(_seedsSpecificationValue);

    }

    private IEnumerable<SpecificationValue> _seedsSpecificationValue
    {
        get
        {
            var specifications = new List<(int Id, string Name,int SpecificationId)>
            {
                (1 , "Yuvarlak", 1),
                (2 , "Kare", 1),
                (3 , "Dikdörtgen", 1),
                (4 , "Sarý", 2),
                (5 , "Metalik",2),
                (6 , "Siyah",2),
                (7 , "Yeþil",2),
                (8 , "Metal",3),
                (9 , "Çelik",3),
                (10, "Yün",3),
                (11, "Muflon",3),
                (12, "30/50",4),
                (13, "70/90",4),
                (14, "90/120",4)
            };
            foreach (var reg in specifications)
            {
                yield return new SpecificationValue
                {
                    Id = reg.Id,
                    Name = reg.Name,
                    SpecificationId= reg.SpecificationId

                };
            }

        }
    }    
}