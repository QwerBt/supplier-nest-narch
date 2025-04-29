using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class JobLevelConfiguration : IEntityTypeConfiguration<JobLevel>
{
    public void Configure(EntityTypeBuilder<JobLevel> builder)
    {
        builder.ToTable("JobLevels").HasKey(jl => jl.Id);

        builder.Property(jl => jl.Id).HasColumnName("Id").IsRequired();
        builder.Property(jl => jl.Name).HasColumnName("Name").IsRequired();
        builder.Property(jl => jl.Code).HasColumnName("Code");
        builder.Property(jl => jl.Description).HasColumnName("Description");
        builder.Property(jl => jl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(jl => jl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(jl => jl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasData(_seedsJobLevel);
        builder.HasQueryFilter(jl => !jl.DeletedDate.HasValue);
    }

    private IEnumerable<JobLevel> _seedsJobLevel
    {
        get
        {
            var jobFunctions = new List<(int Id, string Name,string Code)>
            {
                (1,"Yönetici ","Executive"),
                (2,"Koordinatör","Director"),
                (3,"Müdür","Manager"),
                (4,"Bireysel Katkýda Bulunan","Individual" ),
                (5,"Mal sahibi","Owner")
            };
            foreach (var jof in jobFunctions)
            {
                yield return new JobLevel
                {
                    Id = jof.Id,
                    Name = jof.Name,
                    Code = jof.Code

                };
            }

        }
    }



}