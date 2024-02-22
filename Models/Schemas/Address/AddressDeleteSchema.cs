using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Schemas.Address
{
    public class AddressDeleteSchema
    {
        public Guid AddressId { get; set; }

        public static implicit operator Guid(AddressDeleteSchema schema) 
        {
            return schema.AddressId;
        }
    }
}
