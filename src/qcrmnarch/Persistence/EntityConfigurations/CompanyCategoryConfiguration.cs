using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CompanyCategoryConfiguration : IEntityTypeConfiguration<CompanyCategory>
{
    public void Configure(EntityTypeBuilder<CompanyCategory> builder)
    {
        builder.ToTable("CompanyCategories").HasKey(cc => cc.Id);

        builder.Property(cc => cc.Id).HasColumnName("Id").IsRequired();
        builder.Property(cc => cc.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(cc => cc.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cc => cc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cc => cc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cc => !cc.DeletedDate.HasValue);
    }
}