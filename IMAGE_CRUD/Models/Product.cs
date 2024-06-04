using System;
using System.Collections.Generic;

namespace IMAGE_CRUD.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int ProductCategory { get; set; }
        public string ProductImage { get; set; } = null!;
        public int ProductPrice { get; set; }

        public virtual PCategory ProductCategoryNavigation { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
