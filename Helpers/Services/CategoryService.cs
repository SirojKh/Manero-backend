using Manero_Backend.Contexts;
using Manero_Backend.Helpers.Enums;
using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Dtos.Category;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;

namespace Manero_Backend.Helpers.Services;

public class CategoryService : BaseService<CategoryEntity>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository baseRepository) : base(baseRepository)
    {
        _categoryRepository = baseRepository;
    }


    public async Task<bool> ExistsAsync(Guid categoryId)
    {
        return await _categoryRepository.GetByIdAsync(categoryId) != null ? true : false;
    }


    public async Task<CategoryEntity> GetOrCreateAsync(CategoryRequest entityCategory)
    {
        var category = await _categoryRepository
            .SearchSingleAsync(x=>x.Name.ToUpper() == entityCategory.Name.ToUpper());

        if (category is not null)
            return category;

        var response = await CheckIfValidCategoryAsync(entityCategory);
        
        return (await _categoryRepository.SearchSingleAsync(x => x.Name == response.Name))!;

    }
    private async Task<CategoryResponse> CheckIfValidCategoryAsync(CategoryRequest entityCategory)
    {
        foreach (var category in Enum.GetValues(typeof(CategoryEnum)))
        {
            if (category.ToString()?.ToLower() == entityCategory.Name.ToLower())
                return await _categoryRepository.CreateAsync(CategoryFactory.CreateRequest(category.ToString()!.ToUpper()));
        }

        return await _categoryRepository.SearchSingleAsync(x => x.Name.ToUpper() == CategoryEnum.OTHER.ToString().ToUpper())??
               await _categoryRepository.CreateAsync(CategoryFactory.CreateRequest(CategoryEnum.OTHER.ToString()!.ToUpper()));
    }
}