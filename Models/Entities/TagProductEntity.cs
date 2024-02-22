namespace Manero_Backend.Models.Entities
{
    public class TagProductEntity : BaseEntity
    {
        public Guid TagId { get; set; }
        public TagEntity Tag { get; set; }
        public Guid ProductId { get; set; }  
        public ProductEntity Product { get; set; }
    }
}
