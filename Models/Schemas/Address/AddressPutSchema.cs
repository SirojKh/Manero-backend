using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Schemas.Address
{
    public class AddressPutSchema
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public static implicit operator AddressEntity(AddressPutSchema schema)
        {
            return new AddressEntity()
            {
                Id = schema.Id,
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
