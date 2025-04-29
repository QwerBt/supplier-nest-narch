using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SpecificationConfiguration : IEntityTypeConfiguration<Specification>
{
    public void Configure(EntityTypeBuilder<Specification> builder)
    {
        builder.ToTable("Specifications").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.Name).HasColumnName("Name").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");


        builder.HasMany(s => s.SpecificationValues)
            .WithOne(sv => sv.Specification)
            .HasForeignKey(s => s.SpecificationId)
            .OnDelete(DeleteBehavior.Restrict);
  

        builder.HasMany(s => s.ItemSpecifications)
            .WithOne(isp => isp.Specification) // Use WithOne for one-to-many relationship
            .HasForeignKey(isp => isp.SpecificationId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        builder.HasData(_seedsSpecification);

    }

    private IEnumerable<Specification> _seedsSpecification
    {
        get
        {
            var specifications = new List<(int Id, string Name)>
            {
                    (1,"Þekil"),
                    (2,"Renk"),
                    (3,"Malzeme"),
                    (4,"Ölçü"),
            };
            foreach (var reg in specifications)
            {
                yield return new Specification
                {
                    Id = reg.Id,
                    Name = reg.Name

                };
            }

        }
    }


}