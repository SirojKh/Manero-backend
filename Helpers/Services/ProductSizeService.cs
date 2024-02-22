using Manero_Backend.Helpers.Repositories;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;

namespace Manero_Backend.Helpers.Services
{
    public class ProductSizeService : BaseService<ProductSizeEntity>, IProductSizeService
    {
        private readonly IProductSizeRepository _productSizeRepository;

        public ProductSizeService(IProductSizeRepository productSizeRepository) : base(productSizeRepository)
        {
            _productSizeRepository = productSizeRepository;
        }

    }
}
