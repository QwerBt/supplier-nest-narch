using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.InteropServices;
using System;

namespace Persistence.EntityConfigurations;

public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.ToTable("Disciplines").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.Name).HasColumnName("Name").IsRequired();
        builder.Property(d => d.Code).HasColumnName("Code");
        builder.Property(d => d.Description).HasColumnName("Description");
        builder.Property(d => d.JobFunctionId).HasColumnName("JobFunctionId").IsRequired();
        //builder.Property(d => d.JobFunction).HasColumnName("JobFunction").IsRequired();
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");
       

        builder.HasData(_seedsDiscipline);
        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
    }

    private IEnumerable<Discipline> _seedsDiscipline
    {
        get
        {
            var disciplines = new List<(int Id, int jobfunctionId, string Name,string Code)>
            {
                (1,1,"Elektrik","Electrical"),
                (2,1,"Mekanik","Mechanical"),
                (3,1,"Endüstri","Industrial"),
                (4,1,"Tasarým","Design"),
                (5,1,"Ýnþaat","Civil"),
                (6,1,"Mimari","Architectural"),
                (7,1,"Bilgisayar Bilimi","ComputerScience"),
                (8,1,"Havacýlýk ve Uzay","Aerospace"),
                (9,1,"Çevre","Environmental"),
                (10,1,"Kimya","Chemical"),
                (11,1,"Danýþmanlýk","Consulting"),
                (12,1,"Diðer","Other"),

                (13,2,"Tedarik Zinciri","SupplyChain"),
                (14,2,"Satýn Alma","Purchasing"),
                (15,2,"Tedarik","Procurement"),
                (16,2,"Lojistik","Logistics"),
                (17,2,"Toplu Taþýma","Transportation"),
                (18,2,"Depolama","Warehousing"),
                (19,2,"Daðýtým","Distribution"),
                (20,2,"Envanter","Inventory"),
                (21,2,"Malzemeler","Materials"),
                (22,2,"Danýþmanlýk","Consulting"),

                (23,3,"Üretim Mühendisliði","ProductEngineering"),
                (24,3,"Üretim Yönetimi","ProductManagement"),
                (25,3,"Kalite Kontrol","Quality"),
                (26,3,"Operasyonlar","Operations"),
                (27,3,"Bakým & Onarým","MaintenanceRepair"),
                (28,3,"Danýþmanlýk","Consulting"),

                (29,4,"Mühendislik Yönetimi", "ManagementEngineering"),
                (30,4,"Tedarik Yönetimi","ManagementProcurement"),
                (31,4,"Operasyon Yönetimi", "ManagementOperations"),
                (32,4,"BT","Management IT"  ),

                ( 33,5,"Satýþ","Sales"),
                ( 34,5,"Pazarlama","SalesMarketing"),
                ( 35,5,"Satýþ ve Pazarlama","SalesSalesMarketing"),
                ( 36,5,"Acenteler","SalesAgency"),
                ( 37,5,"Danýþmanlýk","SalesConsultant"),

                (38,6,"Danýþman","Other Consultant"),
                (39,6,"Öðrenci","Other Student"),
                (40,6,"Emekli","Other Retired"),
                (41,6,"Eðitimci","Other Educator"),


            };
            foreach (var dis in disciplines)
            {
                yield return new Discipline
                {
                    Id = dis.Id,
                    JobFunctionId = dis.jobfunctionId,
                    Name = dis.Name,
                    Code = dis.Code

                };
            }

        }
    }
}