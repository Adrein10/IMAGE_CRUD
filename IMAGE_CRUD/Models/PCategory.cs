using System;
using System.Collections.Generic;

namespace IMAGE_CRUD.Models
{
    public partial class PCategory
    {
        public PCategory()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
