using ASOS.BL.DTOs;
using ASOS.DAL;

using Microsoft.Extensions.Configuration;


namespace ASOS.BL;

public class MenManager : IMenManager
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IConfiguration _configuration;

    public MenManager(IUnitOfWork unitOfWork,IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;

    }

    public async Task<List<ProductDTO>> GetAllAsync()
    {
        // Mapping from db model to business model
        var productFromDB = await _unitOfWork.Products.GetAllProductAsync();
        var menProducts = productFromDB.Where(p => p.Section == Section.Male);

        return menProducts.Select(d => new ProductDTO
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
}
