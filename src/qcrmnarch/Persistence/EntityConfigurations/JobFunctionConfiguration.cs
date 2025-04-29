using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class JobFunctionConfiguration : IEntityTypeConfiguration<JobFunction>
{
    public void Configure(EntityTypeBuilder<JobFunction> builder)
    {
        builder.ToTable("JobFunctions").HasKey(jf => jf.Id);

        builder.Property(jf => jf.Id).HasColumnName("Id").IsRequired();
        builder.Property(jf => jf.Name).HasColumnName("Name").IsRequired();
        builder.Property(jf => jf.Code).HasColumnName("Code");
        builder.Property(jf => jf.Description).HasColumnName("Description");
        builder.Property(jf => jf.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(jf => jf.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(jf => jf.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(c => c.Disciplines)
            .WithOne(ca => ca.JobFunction)
            .HasForeignKey(ca => ca.JobFunctionId) // Foreign Key'i burada belirtiyoruz
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(_seedsJobFunction);
        builder.HasQueryFilter(jf => !jf.DeletedDate.HasValue);
    }

    private IEnumerable<JobFunction> _seedsJobFunction
    {
        get
        {
            var jobFunctions = new List<(int Id, string Name)>
            {
            (1, "Mühendislik / Tasarým"),
            (2, "Tedarik Zinciri / Tedarik / Lojistik"),
            (3, "Üretim / Operasyonlar"),
            (4, "Genel Müdürlük"),
            (5, "Satýþ ve Pazarlama"),
            (6, "Diðer")
            };
            foreach (var jof in jobFunctions)
            {
                yield return new JobFunction
                {
                    Id = jof.Id,
                    Name = jof.Name

                };
            }

        }
    }
}