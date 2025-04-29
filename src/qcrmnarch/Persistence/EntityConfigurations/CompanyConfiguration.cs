using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies").HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(c => c.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(c => c.TaxId)
            .HasColumnName("TaxId")
            .HasMaxLength(50);

        builder.Property(c => c.Phone1)
            .HasColumnName("Phone1")
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(c => c.Phone2)
            .HasColumnName("Phone2")
            .HasMaxLength(15);

        builder.Property(c => c.Email)
            .HasColumnName("Email")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Website)
            .HasColumnName("Website")
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(c => c.Description)
            .HasColumnName("Description")
            .IsRequired();

        builder.Property(c => c.BankAccountNumber)
            .HasColumnName("BankAccountNumber")
            .HasMaxLength(50);

        builder.Property(c => c.BankName)
            .HasColumnName("BankName")
            .HasMaxLength(100);

        builder.Property(c => c.IsVerified)
            .HasColumnName("IsVerified");

        builder.Property(c => c.CreditLimit)
            .HasColumnName("CreditLimit")
            .HasColumnType("decimal(18,2)");

        builder.Property(c => c.PaymentTerms)
            .HasColumnName("PaymentTerms")
            .HasMaxLength(255);

        builder.Property(c => c.FacebookUrl)
            .HasColumnName("FacebookUrl")
            .HasMaxLength(255);

        builder.Property(c => c.TwitterUrl)
            .HasColumnName("TwitterUrl")
            .HasMaxLength(255);

        builder.Property(c => c.LinkedInUrl)
            .HasColumnName("LinkedInUrl")
            .HasMaxLength(255);

        builder.Property(c => c.IsActive)
            .HasColumnName("IsActive")
            .IsRequired();

        builder.Property(c => c.IndustryId)
            .HasColumnName("IndustryId")
            .IsRequired();

        builder.Property(c => c.CreatedDate)
            .HasColumnName("CreatedDate")
            .IsRequired();

        builder.Property(c => c.UpdatedDate)
            .HasColumnName("UpdatedDate");

        builder.Property(c => c.DeletedDate)
            .HasColumnName("DeletedDate");



        // 📌 Industry - Company (One-to-Many) İlişkisi
        builder.HasOne(c => c.Industry)  // Company bir Industry'ye bağlı
            .WithMany(i => i.Companies)  // Bir Industry birden fazla Company içerebilir
            .HasForeignKey(c => c.IndustryId) // Foreign Key
            .OnDelete(DeleteBehavior.Restrict); // Silme davranışı


        builder.HasMany(c => c.CompanyAddresses)
            .WithOne(ca => ca.Company)
            .HasForeignKey(ca => ca.CompanyId) // Foreign Key'i burada belirtiyoruz
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.CompanyContacts)
            .WithOne(ca=>ca.Company)
            .HasForeignKey(ca => ca.CompanyId) // Foreign Key'i burada belirtiyoruz
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Transactions)
             .WithOne(t=>t.Company)
             .HasForeignKey(t => t.CompanyId) // Foreign Key'i burada belirtiyoruz
             .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(builder => builder.CompanyCategories)
               .WithOne(cc => cc.Company)
               .HasForeignKey(cc => cc.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(builder => builder.CompanyBrands)
               .WithOne(cc => cc.Company)
               .HasForeignKey(cc => cc.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

    }
}
