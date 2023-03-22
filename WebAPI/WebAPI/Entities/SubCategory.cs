using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Products = new HashSet<Product>();
        }

        public int SubCategoriesId { get; set; }
        public string? SubCategoriesName { get; set; }
        public int? CategoriesId { get; set; }

        public virtual Category? Categories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
