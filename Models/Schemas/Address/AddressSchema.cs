using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Schemas.Address
{
    public class AddressSchema
    {
        public string Title { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public static implicit operator AddressEntity(AddressSchema schema)
        {
            return new AddressEntity()
            {
                Title = schema.Title,
                FirstName = schema.FirstName,
                LastName = schema.LastName,
                Street = schema.Street,
                PostalCode = schema.PostalCode,
                City = schema.City
            };
        }
    }
}
