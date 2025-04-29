using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ItemUomConfiguration : IEntityTypeConfiguration<ItemUom>
{
    public void Configure(EntityTypeBuilder<ItemUom> builder)
    {
        builder.ToTable("ItemUoms").HasKey(iu => iu.Id);

        builder.Property(iu => iu.Id).HasColumnName("Id").IsRequired();
        builder.Property(iu => iu.ItemId).HasColumnName("ItemId").IsRequired();
        builder.Property(iu => iu.UomId).HasColumnName("UomId").IsRequired();
        builder.Property(iu => iu.ConversionRate).HasColumnName("ConversionRate").IsRequired();
        builder.Property(iu => iu.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(iu => iu.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(iu => iu.DeletedDate).HasColumnName("DeletedDate");

        // Define the relationship with Item (by Foreign Key)
        builder.HasOne(iu => iu.Item)
            .WithMany(i => i.ItemUoms) // Many ItemUoms for each Item
            .HasForeignKey(iu => iu.ItemId) // Foreign Key property
            .OnDelete(DeleteBehavior.Restrict); // Adjust delete behavior as needed

 

        builder.HasQueryFilter(iu => !iu.DeletedDate.HasValue);
    }
}
