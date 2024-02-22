using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;

namespace Manero_Backend.Helpers.Services
{
    public class ProductColorService : BaseService<ProductColorEntity>, IProductColorService
    {
        private readonly IProductColorRepository _productColorRepository;

        public ProductColorService(IProductColorRepository productColorRepository) : base(productColorRepository)
        {
            _productColorRepository = productColorRepository;
        }

    }
}
