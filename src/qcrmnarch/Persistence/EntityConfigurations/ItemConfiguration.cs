using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.Code).HasColumnName("Code").IsRequired();
        builder.Property(i => i.Name).HasColumnName("Name").IsRequired();
        builder.Property(i => i.Description).HasColumnName("Description").IsRequired();
        builder.Property(i => i.UnitPrice).HasColumnName("UnitPrice").IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

 
        // Transaction iliþkisini yapýlandýrma
        builder.HasOne(i => i.Product)
            .WithMany(i => i.Items)
            .HasForeignKey(td => td.ProductId);

        builder.HasMany(i => i.ItemSpecifications) // Item birden fazla ItemSpecification'a sahip
        .WithOne(ispec => ispec.Item)       // ItemSpecification bir Item'e ait
        .HasForeignKey(ispec => ispec.ItemId) // ItemId yabancý anahtar
        .OnDelete(DeleteBehavior.Restrict); // Silme davranýþý (isteðe baðlý)
 
        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}