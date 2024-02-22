using Manero_Backend.Contexts;
using Manero_Backend.Helpers.Factory;
using Manero_Backend.Helpers.JWT;
using Manero_Backend.Models.Dtos.Category;
using Manero_Backend.Models.Dtos.Product;
using Manero_Backend.Models.Dtos.Review;
using Manero_Backend.Models.Dtos.Tag;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;
using Manero_Backend.Models.Schemas.Product;
using Microsoft.AspNetCore.Mvc;


namespace Manero_Backend.Helpers.Services;

public class ProductService : BaseService<ProductEntity>, IProductService

{
    private readonly IProductRepository _productRepository;
    private readonly ITagService _tagService;
    private readonly ICategoryService _categoryService;
    private readonly IReviewService _reviewService;

	private readonly ITagProductService _tagProductService;
	private readonly IProductColorService _productColorService;
	private readonly IProductSizeService _productSizeService;
	private readonly IWishService _wishService;
    private readonly ISizeService _sizeService;
    private readonly IColorService _colorService;
    private readonly ICompanyService _companyService;
    public ProductService(IProductRepository baseRepository, ITagService tagService, ICategoryService categoryService, IReviewService reviewService, ITagProductService tagProductService, IProductColorService productColorService, IProductSizeService productSizeService, IWishService wishService, ISizeService sizeService, IColorService colorService, ICompanyService companyService) : base(baseRepository)
    {
        _productRepository = baseRepository;
        _tagService = tagService;
        _categoryService = categoryService;
        _reviewService = reviewService;
        _tagProductService = tagProductService;
        _productColorService = productColorService;
        _productSizeService = productSizeService;
        _wishService = wishService;
        _sizeService = sizeService;
        _colorService = colorService;
        _companyService = companyService;
    }


    public async Task<IActionResult> GetByGuid(Guid guid, string userId)
	{
		ProductEntity entity = await _productRepository.GetByGuid(guid);
		if (entity == null)
			return HttpResultFactory.NotFound("");

		var productDto = (ProductDto)entity;
		productDto.Liked = await _wishService.ExistsAsync(guid, userId);

        return  HttpResultFactory.Ok(productDto);
	}

    public async Task<IActionResult> GetByOptions(IEnumerable<ProductOptionSchema> schema, string userId)
    {
		List<object> result = new List<object>();

        foreach (var productOption in schema)
		{
			if (productOption.TagId == null && productOption.CategoryId == null) //1.
			{
				result.Add(new { Option = productOption, Result = string.Empty, ErrorMessage = "Provide at least a TagId or a CategoryId." });
                
				continue;
			}

            if (productOption.TagId != null && productOption.CategoryId != null)
            {
                if ((await _categoryService.ExistsAsync((Guid)productOption.CategoryId) == false) || (await _tagService.ExistsAsync((Guid)productOption.TagId) == false))
                {
                    result.Add(new { Option = productOption, Result = string.Empty, ErrorMessage = "Either TagId or CategoryId or both do not exist." });
                    continue;
                }
            }

            result.Add(new { Option = productOption, Result = (await _productRepository.GetByOption(productOption)).Select(x => 
			{
				var productMinDto = (ProductMinDto)x;
				productMinDto.Liked = x.WishList.Where(y => y.AppUserId == userId && y.ProductId == x.Id).FirstOrDefault() != null;
                return productMinDto;
            }), ErrorMessage = string.Empty });
        }

		return HttpResultFactory.Ok(result);
    }


	public async Task<IActionResult> CreateAsync(ProductSchema schema)
	{
        // Null checks for schema properties
        if (schema == null)
            return HttpResultFactory.BadRequest("The provided schema is null.");

        if (schema.TagIds == null)
            return HttpResultFactory.BadRequest("TagIds in schema cannot be null.");

        if (schema.SizeIds == null)
            return HttpResultFactory.BadRequest("SizeIds in schema cannot be null.");

        if (schema.ColorIds == null)
            return HttpResultFactory.BadRequest("ColorIds in schema cannot be null.");

        if (schema.CategoryId == Guid.Empty)
            return HttpResultFactory.BadRequest("CategoryId in schema is not valid.");

        if (schema.CompanyId == Guid.Empty)
            return HttpResultFactory.BadRequest("CompanyId in schema is not valid.");

        if (await _tagService.CountAsync(x => schema.TagIds.Contains(x.Id)) != schema.TagIds.Count)
			return HttpResultFactory.BadRequest("Invalid id/s.");

        if (await _sizeService.CountAsync(x => schema.SizeIds.Contains(x.Id)) != schema.SizeIds.Count)
            return HttpResultFactory.BadRequest("Invalid id/s.");

        if(await _colorService.CountAsync(x => schema.ColorIds.Contains(x.Id)) != schema.ColorIds.Count)
            return HttpResultFactory.BadRequest("Invalid id/s.");

        if(!await _categoryService.ExistsAsync(schema.CategoryId))
            return HttpResultFactory.BadRequest("Invalid id/s.");

        if(!await _companyService.ExistsAsync(schema.CompanyId))
            return HttpResultFactory.BadRequest("Invalid id/s.");


        ProductEntity entity = await _productRepository.CreateAsync(schema);
        await _tagProductService.AddRangedAsync(schema.TagIds.Select(x => new TagProductEntity() { TagId = x, ProductId = entity.Id }).ToList());
		
        await _productColorService.AddRangedAsync(schema.ColorIds.Select(x => new ProductColorEntity() { ColorId = x, ProductId = entity.Id }).ToList());
		await _productSizeService.AddRangedAsync(schema.SizeIds.Select(x => new ProductSizeEntity() { SizeId = x, ProductId = entity.Id}).ToList());


		return HttpResultFactory.Created("", "");
	}

    public async Task<decimal> CalcTotalPrice(List<Guid> productIds, Guid companyId, decimal discount)
    {
        return await _productRepository.CalcTotalPrice(productIds, companyId, discount);
    }


    public async Task<IActionResult> SearchAsync(string condition, string userId)
    {
        return HttpResultFactory.Ok((await _productRepository.GetAllIncludeAsync(x => x.Name.Contains(condition)))
            .Select(x =>
            {
                var productMinDto = (ProductMinDto)x;
                productMinDto.Liked = x.WishList.Where(y => y.AppUserId == userId && y.ProductId == x.Id).FirstOrDefault() != null;
                return productMinDto;
            }

            ));
    }

    public async Task<IActionResult> GetAllDevAsync()
    {
        ICollection<ProductEntity> entities = (ICollection<ProductEntity>)await _productRepository.GetAllDevAsync();

        var result = entities.Select(
            x =>
            {
                var productMinDto = (ProductMinDto)x;
                productMinDto.Liked = false;
                return productMinDto;
            }
            );

        return HttpResultFactory.Ok(result);
    }

    public async Task FillDataAsync()
	{
		await _productRepository.FillDataAsync();
	}
}
