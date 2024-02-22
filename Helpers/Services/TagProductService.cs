using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;

namespace Manero_Backend.Helpers.Services
{
    public class TagProductService : BaseService<TagProductEntity>, ITagProductService
    {
        private readonly ITagProductRepository _tagProductRepository;

        public TagProductService(ITagProductRepository tagProductRepository) : base(tagProductRepository)
        {
            _tagProductRepository = tagProductRepository;
        }
    }
}
