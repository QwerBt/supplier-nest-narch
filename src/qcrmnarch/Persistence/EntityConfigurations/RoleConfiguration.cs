using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.Name).HasColumnName("Name").IsRequired();
        builder.Property(r => r.Description).HasColumnName("Description");
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.HasData(_seedsRoles);
        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
    private IEnumerable<Role> _seedsRoles
    {
        get
        {
            var roles = new List<(int Id,  string Name)>
            {
            (1,"Alýcý"),
            (2,"Tedarikçi"),
            (3,"Diðer"),
 
            };
            foreach (var rol in roles)
            {
                yield return new Role
                {
                    Id = rol.Id,
                    Name = rol.Name

                };
            }

        }
    }
}