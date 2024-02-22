using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;

namespace Manero_Backend.Helpers.Services
{
    public class SizeService : BaseService<SizeEntity>, ISizeService
    {
        private readonly ISizeRepository _sizeRepository;

        public SizeService(ISizeRepository sizeRepository) : base(sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }
    }
}
