using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CompanyAddressConfiguration : IEntityTypeConfiguration<CompanyAddress>
{
    public void Configure(EntityTypeBuilder<CompanyAddress> builder)
    {
        builder.ToTable("CompanyAddresses").HasKey(ca => ca.Id);

        builder.Property(ca => ca.Id).HasColumnName("Id").IsRequired();
        builder.Property(ca => ca.Street).HasColumnName("Street").IsRequired();
        builder.Property(ca => ca.CityId).HasColumnName("CityId").IsRequired();
        //builder.Property(ca => ca.City).HasColumnName("City").IsRequired();
        builder.Property(ca => ca.TownId).HasColumnName("TownId").IsRequired();
        //builder.Property(ca => ca.Town).HasColumnName("Town").IsRequired();
        builder.Property(ca => ca.CountryId).HasColumnName("CountryId").IsRequired();
        //builder.Property(ca => ca.Country).HasColumnName("Country").IsRequired();
        builder.Property(ca => ca.PostalCode).HasColumnName("PostalCode").IsRequired();
        builder.Property(ca => ca.Description).HasColumnName("Description").IsRequired();
        builder.Property(ca => ca.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(ca => ca.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ca => ca.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ca => ca.DeletedDate).HasColumnName("DeletedDate");

        // 📌 
        builder.HasOne(c => c.City)  // Company bir Industry'ye bağlı
            .WithMany(i => i.CompanyAddresses)  // Bir Industry birden fazla Company içerebilir
            .HasForeignKey(c => c.CityId) // Foreign Key
            .OnDelete(DeleteBehavior.Restrict); // Silme davranışı

        // 📌 
        builder.HasOne(c => c.Town)  // Company bir Industry'ye bağlı
            .WithMany(i => i.CompanyAddresses)  // Bir Industry birden fazla Company içerebilir
            .HasForeignKey(c => c.TownId) // Foreign Key
            .OnDelete(DeleteBehavior.Restrict); // Silme davranışı

        // 📌 
        builder.HasOne(c => c.Country)  // Company bir Industry'ye bağlı
            .WithMany(i => i.CompanyAddresses)  // Bir Industry birden fazla Company içerebilir
            .HasForeignKey(c => c.CountryId) // Foreign Key
            .OnDelete(DeleteBehavior.Restrict); // Silme davranışı
                                             



        builder.HasQueryFilter(ca => !ca.DeletedDate.HasValue);
    }
}