using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ItemSpecificationConfiguration : IEntityTypeConfiguration<ItemSpecification>
{
    public void Configure(EntityTypeBuilder<ItemSpecification> builder)
    {
        builder.ToTable("ItemSpecifications").HasKey(isp=> isp.Id);

        builder.Property(isp=> isp.Id).HasColumnName("Id").IsRequired();
        builder.Property(isp=> isp.ItemId).HasColumnName("ItemId").IsRequired();
        builder.Property(isp=> isp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(isp=> isp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(isp=> isp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(builder => builder.Item);
        builder.HasOne(builder => builder.Specification);
        builder.HasOne(builder => builder.SpecificationValue);

        builder.HasQueryFilter(isp=> !isp.DeletedDate.HasValue);
    }
}