namespace IMAGE_CRUD.Models
{
    public class CustomUser
    {
        public UserReg CUser { get; set; }
        public IEnumerable<UserRole> CRoles { get; set; }
    }
}
