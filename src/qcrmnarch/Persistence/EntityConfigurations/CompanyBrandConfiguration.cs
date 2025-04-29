using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CompanyBrandConfiguration : IEntityTypeConfiguration<CompanyBrand>
{
    public void Configure(EntityTypeBuilder<CompanyBrand> builder)
    {
        builder.ToTable("CompanyBrands").HasKey(cb => cb.Id);

        builder.Property(cb => cb.Id).HasColumnName("Id").IsRequired();
        builder.Property(cb => cb.Name).HasColumnName("Name").IsRequired();
        builder.Property(cb => cb.Description).HasColumnName("Description").IsRequired();
        builder.Property(cb => cb.CompanyId).HasColumnName("CompanyId").IsRequired();
        //builder.Property(cb => cb.Company).HasColumnName("Company").IsRequired();
        builder.Property(cb => cb.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cb => cb.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cb => cb.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cb => !cb.DeletedDate.HasValue);
    }
}