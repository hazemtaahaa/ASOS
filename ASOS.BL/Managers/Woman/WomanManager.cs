using ASOS.BL.DTOs;
using ASOS.DAL;
using Microsoft.Extensions.Configuration;

namespace ASOS.BL;

public class WomanManager : IWomanManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public WomanManager(IUnitOfWork unitOfWork,IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public async Task<List<ProductDTO>> GetAllAsync()
    {
        // Mapping from db model to business model
        var productFromDB = await _unitOfWork.Products.GetAllProductAsync();
        var womenProducts = productFromDB.Where(p => p.Section == Section.Female);

        return womenProducts.Select(d => new ProductDTO
        {
            Id = d.Id,
            Name = d.Name,
            Description = d.Description,
            Price = (decimal)d.Price,
            Rate = (decimal)d.Rate,
            Quantity = (int)d.Quantity,
            Section = d.Section,
            UpdatedAt = d.UpdatedAt,
            CreatedAt = d.CreatedAt,
            BrandName = d.Brand?.Name ?? string.Empty,
            CategoryName = d.Category?.Name ?? string.Empty,
            ProductTypeName = d.ProductType?.Name ?? string.Empty,
            ImageUrls = d.ProductImages?.Select(i => $"{_configuration["ApiBaseUrl"]}{i.ImageUrl}").ToList() ?? new List<string>()
        }).ToList();
    }

    public async Task<List<BrandDTO>> GetAllBrandsAsync()
    {
        var productFromDB = await _unitOfWork.Products.GetAllProductAsync();
        var womenProducts = productFromDB.Where(p => p.Section == Section.Female);
        var brands = womenProducts.Select(p => p.Brand).Distinct().ToList();
        var brandDTOs = brands.Select(b => new BrandDTO
        {
            Id = b.Id,
            Name = b.Name,
            BrandImage = $"{_configuration["ApiBaseUrl"]}{b.BrandImage}"
        }).ToList();

        return brandDTOs;
    }
}
