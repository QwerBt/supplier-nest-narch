using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Category : Entity<int>
{
    public Category()
    {
    }

    public Category(string name, string description, int? parentCategoryId, Category parentCategory, ICollection<Category> subCategories, ICollection<Product> products):this()
    {
        Name = name;
        Description = description;
        ParentCategoryId = parentCategoryId;
        ParentCategory = parentCategory;
        SubCategories = subCategories;
        Products = products;
    }

    public string Name { get; set; } // Kategori adı
    public string Description { get; set; } // Kategori açıklaması


    public int? ParentCategoryId { get; set; }
    public virtual Category ParentCategory{ get; set; }
    public virtual ICollection<Category> SubCategories { get; set; }= new HashSet<Category>();
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    public virtual ICollection<CompanyCategory> CompanyCategories { get; set; } = new HashSet<CompanyCategory>();

}
