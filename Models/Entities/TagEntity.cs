using Newtonsoft.Json;

namespace Manero_Backend.Models.Entities
{
    public class TagEntity : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<TagProductEntity> TagProducts { get; set; }


        public bool ShouldSerializeTagProducts()
        {
            return TagProducts == null ? false : true;
        }
    }
}
