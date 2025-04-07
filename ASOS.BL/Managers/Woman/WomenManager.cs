using ASOS.BL.DTOs;
using ASOS.DAL;

namespace ASOS.BL.Managers.Woman
{
    public class WomenManager : IWomanManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public WomenManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductDTO>> GetAllAsync()
        {
            // Mapping from db model to business model
            var productFromDB = await _unitOfWork.Products.GetAllAsync();
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
                BrandId = d.BrandId,
                CategoryId = d.CategoryId,
                ProductTypeId = d.ProductTypeId,
                ImageUrls = d.ProductImages.Select(i => i.ImageUrl).ToList()
            }).ToList();
        }
    }
}
