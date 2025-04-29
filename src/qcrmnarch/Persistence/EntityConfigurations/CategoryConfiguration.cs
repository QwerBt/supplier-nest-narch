using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
        builder.Property(c => c.Description).HasColumnName("Description").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        // Self-referencing relationship for subcategories
        builder.HasOne(c => c.ParentCategory)
               .WithMany(c => c.SubCategories)
               .HasForeignKey(c => c.ParentCategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(builder => builder.Products)
               .WithOne(p => p.Category)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);  
        
        builder.HasMany(builder => builder.CompanyCategories)
               .WithOne(cc => cc.Category)
               .HasForeignKey(cc => cc.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(_seedsCategory);
        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }

 
        private static IEnumerable<Category> _seedsCategory
        {
            get
            {
                var categories = new List<(int Id, string Name, string Description, int? ParentCategoryId)>
            {
                (1, "Metal Malzemeler", "Metaller ve alaþýmlar", null),
                (2, "Plastik ve Polimer Malzemeler", "Plastik ve polimer bazlý malzemeler", null),
                (3, "Ahþap ve Ahþap Ürünleri", "Ahþap bazlý malzemeler", null),
                (4, "Seramik ve Cam Malzemeler", "Seramik ve cam malzemeler", null),
                (5, "Ýnþaat Malzemeleri", "Ýnþaat ve yapý malzemeleri", null),
                (6, "Kimya ve Kimyasal Malzemeler", "Kimyasal maddeler ve ürünler", null),
                (7, "Tekstil ve Tekstil Ürünleri", "Tekstil ve kumaþ ürünleri", null),
                (8, "Elektronik ve Elektrik Malzemeleri", "Elektronik ve elektrik bileþenleri", null),
                (9, "Enerji Malzemeleri", "Enerji üretim ve depolama malzemeleri", null),
                (10, "Otomotiv Malzemeleri", "Otomotiv sektörü için malzemeler", null),
                (11, "Týbbi ve Saðlýk Malzemeleri", "Týbbi cihazlar ve saðlýk ürünleri", null),
                (12, "Ambalaj Malzemeleri", "Ambalaj sektörüne yönelik malzemeler", null),
                (13, "Tarým ve Tarým Malzemeleri", "Tarým makineleri ve ürünleri", null),
                (14, "Havacýlýk ve Uzay Malzemeleri", "Havacýlýk ve uzay teknolojileri", null),
                (15, "Diðer Özel Malzemeler", "Özel ve ileri teknoloji malzemeler", null),

                // Metal Malzemeler
                (16, "Çelik", "Paslanmaz çelik, yapý çeliði", 1),
                (17, "Alüminyum", "Alüminyum ürünleri", 1),
                (18, "Bakýr", "Bakýr malzemeleri", 1),
                (19, "Pirinç", "Pirinç alaþýmlarý", 1),
                (20, "Bronz", "Bronz malzemeleri", 1),
                (21, "Döküm Malzemeleri", "Demir döküm, çelik döküm", 1),
                (22, "Tel ve Kablo Malzemeleri", "Metal bazlý kablolar", 1),

                // Plastik ve Polimer Malzemeler
                (23, "Termoplastikler", "PVC, PE, PP, ABS", 2),
                (24, "Termosetler", "Epoksi, polyester, poliüretan", 2),
                (25, "Kauçuk Malzemeler", "Doðal ve sentetik kauçuk", 2),
                (26, "Kompozit Malzemeler", "Cam elyaf, karbon fiber", 2),

                // Ahþap ve Ahþap Ürünleri
                (27, "Kereste", "Çam, meþe, kayýn", 3),
                (28, "Kontrplak", "Ahþap levhalar", 3),
                (29, "MDF ve Sunta", "Mobilya yapým malzemeleri", 3),
                (30, "Ahþap Kaplamalar", "Ahþap yüzey kaplamalarý", 3),

                // Seramik ve Cam Malzemeler
                (31, "Seramik Karolar", "Ýç ve dýþ kaplamalar", 4),
                (32, "Cam Malzemeler", "Düz cam, temperli cam, lamine cam", 4),
                (33, "Refrakter Malzemeler", "Yüksek sýcaklýða dayanýklý seramikler", 4),

                // Ýnþaat Malzemeleri
                (34, "Çimento ve Beton Ürünleri", "Binalar ve altyapýlar için", 5),
                (35, "Tuðla ve Briket", "Duvar malzemeleri", 5),
                (36, "Yalýtým Malzemeleri", "Strafor, taþ yünü, cam yünü", 5),
                (37, "Çatý Malzemeleri", "Kiremit, çelik çatý, membranlar", 5),
                (38, "Boya ve Kaplamalar", "Ýç ve dýþ boya malzemeleri", 5),

                // Kimya ve Kimyasal Malzemeler
                (39, "Endüstriyel Kimyasallar", "Asitler, bazlar, çözücüler", 6),
                (40, "Yapýþtýrýcýlar ve Sýzdýrmazlýk Malzemeleri", "Farklý endüstriyel uygulamalar", 6),
                (41, "Boya ve Kaplama Kimyasallarý", "Boyama iþlemleri için", 6),
                (42, "Temizlik Kimyasallarý", "Ev ve endüstriyel kullanýmlar", 6),

                // Tekstil ve Tekstil Ürünleri
                (43, "Doðal Lifler", "Pamuk, yün, ipek", 7),
                (44, "Sentetik Lifler", "Polyester, naylon, akrilik", 7),
                (45, "Tekstil Kumaþlarý", "Örme, dokuma, non-woven", 7),
                (46, "Tekstil Kimyasallarý", "Boya, apre malzemeleri", 7),

                 // Elektronik ve Elektrik Malzemeleri
                (50, "Elektronik Komponentler", "Direnç, kapasitör, entegre devreler", 8),
                (51, "Kablo ve Baðlantý Elemanlarý", "Elektrik baðlantý ekipmanlarý", 8),
                (52, "Piller ve Bataryalar", "Enerji depolama çözümleri", 8),
                (53, "Yarý Ýletken Malzemeler", "Elektronik devre elemanlarý", 8),

                // Enerji Malzemeleri
                (54, "Yenilenebilir Enerji Malzemeleri", "Güneþ panelleri, rüzgar türbini parçalarý", 9),
                (55, "Petrol ve Gaz Endüstrisi Malzemeleri", "Boru, vana, pompa", 9),
                (56, "Enerji Depolama Malzemeleri", "Lityum iyon piller, yakýt hücreleri", 9),

                // Otomotiv Malzemeleri
                (57, "Otomotiv Parçalarý", "Motor parçalarý, þasi, aksesuarlar", 10),
                (58, "Lastik ve Jantlar", "Araç lastikleri ve jantlar", 10),
                (59, "Otomotiv Elektroniði", "Araç içi elektronik sistemler", 10),

                // Týbbi ve Saðlýk Malzemeleri
                (60, "Týbbi Cihazlar ve Ekipmanlar", "Hastane ve saðlýk ekipmanlarý", 11),
                (61, "Cerrahi Malzemeler", "Ameliyat ve týbbi müdahale ekipmanlarý", 11),
                (62, "Medikal Tekstil Ürünleri", "Týbbi kullaným için tekstil", 11),
                (63, "Biyomalzemeler", "Biyomedikal uygulamalar için malzemeler", 11),

                // Ambalaj Malzemeleri
                (64, "Karton ve Kaðýt Ambalaj", "Karton kutu, kaðýt torba", 12),
                (65, "Plastik Ambalaj", "Poþet, þiþe, kutu", 12),
                (66, "Metal Ambalaj", "Teneke kutu, alüminyum folyo", 12),
                (67, "Cam Ambalaj", "Cam þiþeler ve kaplar", 12),

                // Tarým ve Tarým Malzemeleri
                (68, "Tarým Makineleri ve Ekipmanlarý", "Tarým sektörüne yönelik makineler", 13),
                (69, "Gübre ve Toprak Düzenleyiciler", "Tarým için kimyasal ve organik gübreler", 13),
                (70, "Sulama Sistemleri", "Tarýmsal sulama çözümleri", 13),
                (71, "Sera Malzemeleri", "Sera yapýmý ve ekipmanlarý", 13),

                // Havacýlýk ve Uzay Malzemeleri
                (72, "Kompozit Malzemeler", "Karbon fiber, aramid fiber", 14),
                (73, "Yüksek Performanslý Alaþýmlar", "Havacýlýk ve uzay için özel alaþýmlar", 14),

                // Diðer Malzemeler
                (47, "Nanomalzemeler", "Geliþmiþ nanoteknoloji malzemeleri", 15),
                (48, "Akýllý Malzemeler", "Þekil hafýzalý alaþýmlar, piezoelektrik malzemeler", 15),
                (49, "Biyobozunur Malzemeler", "Çevre dostu malzemeler", 15)
            };

                foreach (var cat in categories)
                {
                    yield return new Category
                    {
                        Id = cat.Id,
                        Name = cat.Name,
                        Description = cat.Description,
                        ParentCategoryId = cat.ParentCategoryId
                    };
                }
            }
        }
    }

