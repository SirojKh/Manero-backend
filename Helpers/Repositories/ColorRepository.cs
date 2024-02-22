using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Helpers.Repositories
{
    public class ColorRepository : BaseRepository<ColorEntity>, IColorRepository
    {
        private readonly ManeroDbContext _context;

        public ColorRepository(ManeroDbContext context) : base(context)
        {
            _context = context;
        }

        
    }
}
