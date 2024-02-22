using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Dtos.Address;

namespace Manero_Backend.Models.Entities
{
    public class AddressEntity : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; }

        public ICollection<OrderEntity> Orders { get; set; } //M:1

        public static implicit operator AddressDto(AddressEntity entity)
        {
            return new AddressDto()
            {
                Id = entity.Id,
                Title = entity.Title,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Street = entity.Street,
                PostalCode = entity.PostalCode,
                City = entity.City
            };
        }

    }
}
