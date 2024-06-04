using System;
using System.Collections.Generic;

namespace IMAGE_CRUD.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserRegs = new HashSet<UserReg>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<UserReg> UserRegs { get; set; }
    }
}
