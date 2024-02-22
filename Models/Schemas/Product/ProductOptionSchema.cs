namespace Manero_Backend.Models.Schemas.Product
{
    public class ProductOptionSchema
    {
        public int Count { get; set; }
        public Guid? TagId { get; set; } 
        public Guid? CategoryId { get; set; }
    }
}
