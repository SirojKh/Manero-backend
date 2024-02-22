using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Manero_Backend.Helpers.Repositories
{
    public class TagRepository : BaseRepository<TagEntity>, ITagRepository
	{
		private readonly ManeroDbContext _context;
		public TagRepository(ManeroDbContext context) : base(context)
		{
			_context = context;
		}
		
		public async Task<TagEntity> GetByTagAsync(string tag)
		{
			var result = await _context.Tags.FirstOrDefaultAsync(x => x.Name == tag);
			return result!;
		}
	}
}
