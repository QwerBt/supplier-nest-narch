using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CompanyUserConfiguration : IEntityTypeConfiguration<CompanyUser>
{
    public void Configure(EntityTypeBuilder<CompanyUser> builder)
    {
        builder.ToTable("CompanyUsers").HasKey(cu => cu.Id);

        builder.Property(cu => cu.Id).HasColumnName("Id").IsRequired();
        builder.Property(cu => cu.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(cu => cu.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(cu => cu.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cu => cu.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cu => cu.DeletedDate).HasColumnName("DeletedDate");

        // Define relationships and foreign keys for Company and User
        builder.HasOne(cu => cu.Company)
            .WithMany() // If Company has many CompanyUsers, you can specify the navigation property
            .HasForeignKey(cu => cu.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cu => cu.User)
            .WithMany() // If User has many CompanyUsers, you can specify the navigation property
            .HasForeignKey(cu => cu.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(cu => !cu.DeletedDate.HasValue);
    }
}
