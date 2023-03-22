using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? NumStar { get; set; }
        public string? Comment { get; set; }
        public DateTime? DateAdded { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product? Product { get; set; }
    }
}
