using System;
using System.Collections.Generic;

namespace IMAGE_CRUD.Models
{
    public partial class UserReg
    {
        public UserReg()
        {
            Carts = new HashSet<Cart>();
        }

        public int Userid { get; set; }
        public string Username { get; set; } = null!;
        public string Useremail { get; set; } = null!;
        public string Userpass { get; set; } = null!;
        public int Userrole { get; set; }

        public virtual UserRole UserroleNavigation { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
