using ASOS.BL.DTOs;
using ASOS.DAL;

namespace ASOS.BL;

public class MenManager : IMenManager
{
    private readonly IUnitOfWork _unitOfWork;

    public MenManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
            UpdatedAt = (DateTime)d.UpdatedAt,
            CreatedAt = d.CreatedAt,
            BrandName = d.Brand.Name,
            CategoryName = d.Category.Name,
            ProductTypeName = d.ProductType.Name,
            ImageUrls = d.ProductImages.Select(i => i.ImageUrl).ToList()
        }).ToList();
    }
}
