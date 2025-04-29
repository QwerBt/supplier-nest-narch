using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Product:Entity<int>
{
    public Product()
    {
        Items=new HashSet<Item>();
        ProductImages = new HashSet<ProductImage>();
    }

    public Product(string name, string description, int categoryId, Category category, ICollection<Item> items, ICollection<ProductImage> productImages):this()
    {
        Name = name;
        Description = description;
        CategoryId = categoryId;
        Category = category;
        Items = items;
        ProductImages = productImages;
    }

        public string Name{ get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
    public virtual Category Category { get; set; }  
    public virtual ICollection<Item> Items { get; set; }
    public virtual ICollection<ProductImage> ProductImages { get; set; }

}
