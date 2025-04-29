using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CompanyContactConfiguration : IEntityTypeConfiguration<CompanyContact>
{
    public void Configure(EntityTypeBuilder<CompanyContact> builder)
    {
        builder.ToTable("CompanyContacts").HasKey(cc => cc.Id);

        builder.Property(cc => cc.Id).HasColumnName("Id").IsRequired();
        builder.Property(cc => cc.FullName).HasColumnName("FullName").IsRequired();
        builder.Property(cc => cc.Phone1).HasColumnName("Phone1").IsRequired();
        builder.Property(cc => cc.Phone2).HasColumnName("Phone2").IsRequired();
        builder.Property(cc => cc.Email).HasColumnName("Email").IsRequired();
        builder.Property(cc => cc.Position).HasColumnName("Position").IsRequired();
        builder.Property(cc => cc.IsPrimary).HasColumnName("IsPrimary").IsRequired();
        builder.Property(cc => cc.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cc => cc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cc => cc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cc => !cc.DeletedDate.HasValue);
    }
}