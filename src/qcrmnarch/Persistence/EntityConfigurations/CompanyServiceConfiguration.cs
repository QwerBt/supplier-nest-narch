using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CompanyServiceConfiguration : IEntityTypeConfiguration<CompanyService>
{
    public void Configure(EntityTypeBuilder<CompanyService> builder)
    {
        builder.ToTable("CompanyServices").HasKey(cs => cs.Id);

        builder.Property(cs => cs.Id).HasColumnName("Id").IsRequired();
        builder.Property(cs => cs.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(cs => cs.ServicesId).HasColumnName("ServicesId").IsRequired();
        builder.Property(cs => cs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cs => cs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cs => cs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cs => !cs.DeletedDate.HasValue);
    }
}