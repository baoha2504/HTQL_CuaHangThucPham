using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
