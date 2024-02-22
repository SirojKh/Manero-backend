using Manero_Backend.Helpers.Factory;
using Manero_Backend.Helpers.Repositories;
using Manero_Backend.Models.Dtos.Address;
using Manero_Backend.Models.Dtos.Product;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;
using Manero_Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero_Backend.Helpers.Services
{
    public class AddressService : BaseService<AddressEntity>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository) : base(addressRepository) 
        {
            _addressRepository = addressRepository;
        }

        public async Task<IActionResult> CreateAsync(AddressEntity entity, string userId)
        {
            entity.AppUserId = userId;

            await _addressRepository.CreateAsync(entity);

            return HttpResultFactory.Created("","");
        }


        public async Task<IActionResult> RemoveAsync(Guid addressId, string userId)
        {
            AddressEntity entity = await _addressRepository.GetAsync(addressId, userId);
            if (entity == null)
                return HttpResultFactory.NotFound("");

            await _addressRepository.RemoveAsync(entity);

            return HttpResultFactory.NoContent();
        }

        public async Task<IActionResult> GetAllAsync(string userId)
        {
            return HttpResultFactory.Ok((await _addressRepository.GetUserAddressesAsync(userId)).Select(x => (AddressDto)x));
        }

        public async Task<IActionResult> PutAsync(AddressEntity entity, string userId)
        {
            AddressEntity originalEntity = await _addressRepository.GetAsync(entity.Id, userId);
            if (originalEntity == null)
                return HttpResultFactory.NotFound("");

            originalEntity.Title = entity.Title;
            originalEntity.FirstName = entity.FirstName;
            originalEntity.LastName = entity.LastName;
            originalEntity.Street = entity.Street;
            originalEntity.City = entity.City;
            originalEntity.PostalCode = entity.PostalCode;


            await _addressRepository.UpdateAsync(originalEntity);

            return HttpResultFactory.NoContent();
        }

        public async Task<bool> ExistsAsync(Expression<Func<AddressEntity, bool>> predicate)
        {
            return await _addressRepository.ExistsAsync(predicate);
        }
    }
}
