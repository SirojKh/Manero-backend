using Manero_Backend.Contexts;
using Manero_Backend.Helpers.Enums;
using Manero_Backend.Helpers.Factory;
using Manero_Backend.Helpers.Repositories;
using Manero_Backend.Models.Dtos.Tag;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;

namespace Manero_Backend.Helpers.Services;

public class TagService : BaseService<TagEntity>, ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository) : base(tagRepository)
    {
        _tagRepository = tagRepository;
    }
}