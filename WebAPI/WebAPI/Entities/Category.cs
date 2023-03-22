using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Category
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }

        public int CategoriesId { get; set; }
        public string? CategoriesName { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
