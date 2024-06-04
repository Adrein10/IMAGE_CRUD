using System;
using System.Collections.Generic;

namespace IMAGE_CRUD.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Unitprice { get; set; }
        public int Quantity { get; set; }
        public int Totalprice { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual UserReg User { get; set; } = null!;
    }
}
