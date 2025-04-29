using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Application.Dtos;
using Nest;

namespace Persistence.EntityConfigurations;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("Regions").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.Name).HasColumnName("Name").IsRequired();
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");


        builder.HasMany(c => c.Cities)
            .WithOne(ca => ca.Region)
            .HasForeignKey(ca => ca.RegionId) // Foreign Key'i burada belirtiyoruz
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Country)
            .WithMany(ca => ca.Regions)
            .HasForeignKey(ca => ca.CountryId) // Foreign Key'i burada belirtiyoruz
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
        builder.HasData(_seedsRegion);

    }
    private IEnumerable<Region> _seedsRegion
    {
        get
        {
            var regions = new List<(int Id,int CountryId, string Name)>
            {
            (1, 225 , "Akdeniz Bölgesi"),
            (2, 225 , "Doðu Anadolu Bölgesi"),
            (3, 225 , "Ege Bölgesi"),
            (4, 225 , "Güneydoðu Anadolu Bölgesi"),
            (5, 225 , "Ýç Anadolu Bölgesi"),
            (6, 225 , "Karadeniz Bölgesi"),
            (7, 225 , "Marmara Bölgesi")
            };
            foreach (var reg in regions)
            {
                yield return new Region
                {
                    Id = reg.Id,
                    CountryId = reg.CountryId,
                    Name = reg.Name

                };
            }

        }
    }


}