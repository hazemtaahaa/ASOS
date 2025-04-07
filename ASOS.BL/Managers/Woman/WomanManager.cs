using ASOS.BL.DTOs;
using ASOS.DAL;

namespace ASOS.BL;

public class WomanManager : IWomanManager
{
    private readonly IUnitOfWork _unitOfWork;

    public WomanManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
            UpdatedAt = (DateTime)d.UpdatedAt,
            CreatedAt = d.CreatedAt,
            BrandName = d.Brand.Name,
            CategoryName = d.Category.Name,
            ProductTypeName = d.ProductType.Name,
            ImageUrls = d.ProductImages.Select(i => i.ImageUrl).ToList()
        }).ToList();
    }
}
