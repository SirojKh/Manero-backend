using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero_Backend.Helpers.Services;

public class BaseService<TEntity> : IBaseService<TEntity> where  TEntity : class
{

    private readonly IBaseRepository<TEntity> _baseRepository;

    public BaseService(IBaseRepository<TEntity> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _baseRepository.ExistsAsync(id);
    }
    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _baseRepository.ExistsAsync(predicate);
    }
    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _baseRepository.CountAsync(predicate);
    }

    public async Task AddRangedAsync(ICollection<TEntity> entities)
    {
        await _baseRepository.AddRangedAsync(entities);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _baseRepository.GetAllAsync(predicate);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        return await _baseRepository.UpdateAsync(entity);
    }


    public async Task<IActionResult> GetAllAsync()
    {
        return HttpResultFactory.Ok(await _baseRepository.GetAllAsync());
    }
}