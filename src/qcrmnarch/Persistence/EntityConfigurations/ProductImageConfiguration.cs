using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable("ProductImages").HasKey(ii => ii.Id);

        builder.Property(ii => ii.Id).HasColumnName("Id").IsRequired();
        builder.Property(ii => ii.ProductId).HasColumnName("ItemId").IsRequired();
        //builder.Property(ii => ii.Item).HasColumnName("Item").IsRequired();
        builder.Property(ii => ii.FilePath).HasColumnName("FilePath").IsRequired();
        builder.Property(ii => ii.FileName).HasColumnName("FileName").IsRequired();
        builder.Property(ii => ii.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ii => ii.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ii => ii.DeletedDate).HasColumnName("DeletedDate");

        // Þirket ile iliþkiyi burada belirtin
        builder.HasOne<Product>()
            .WithMany(c => c.ProductImages)
            .HasForeignKey(ci => ci.ProductId)
            .OnDelete(DeleteBehavior.Cascade); //   silindiðinde, resimler de silinsin

        builder.HasQueryFilter(ii => !ii.DeletedDate.HasValue);
    }
}