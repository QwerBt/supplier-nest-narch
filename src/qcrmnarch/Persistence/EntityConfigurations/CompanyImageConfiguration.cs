using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CompanyImageConfiguration : IEntityTypeConfiguration<CompanyImage>
{
    public void Configure(EntityTypeBuilder<CompanyImage> builder)
    {
        builder.ToTable("CompanyImages").HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id).HasColumnName("Id").IsRequired();
        builder.Property(ci => ci.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(ci => ci.FilePath).HasColumnName("FilePath").IsRequired();
        builder.Property(ci => ci.FileName).HasColumnName("FileName").IsRequired();
        builder.Property(ci => ci.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ci => ci.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ci => ci.DeletedDate).HasColumnName("DeletedDate");


        // Þirket ile iliþkiyi burada belirtin
        builder.HasOne<Company>()
            .WithMany(c => c.CompanyImages)
            .HasForeignKey(ci => ci.CompanyId)
            .OnDelete(DeleteBehavior.Cascade); // Þirket silindiðinde, resimler de silinsin


        builder.HasQueryFilter(ci => !ci.DeletedDate.HasValue);
    }
}