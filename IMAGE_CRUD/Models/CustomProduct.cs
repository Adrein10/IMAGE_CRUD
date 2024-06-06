namespace IMAGE_CRUD.Models
{
    public class CustomProduct
    {
        public Product? CProduct { get; set; }
        public IEnumerable<PCategory>? CPCategory { get; set; }
    }
}
