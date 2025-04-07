using ASOS.BL.DTOs;
using ASOS.DAL;

namespace ASOS.BL.Managers.Product
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ProductDTO>> GetAllAsync()
        {
            var products= await _unitOfWork.Products.GetAllProductAsync();

            return products.Select(d => new ProductDTO
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
        public async Task<ProductDTO> GetByIdAsync(Guid Id)
        {
            var product= await _unitOfWork.Products.GetProductById(Id);

            return  new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = (decimal)product.Price,
                Rate = (decimal)product.Rate,
                Quantity = (int)product.Quantity,
                Section = product.Section,
                UpdatedAt = (DateTime)product.UpdatedAt,
                CreatedAt = product.CreatedAt,
                BrandName = product.Brand.Name,
                CategoryName = product.Category.Name,
                ProductTypeName = product.ProductType.Name,
                ImageUrls = product.ProductImages.Select(i => i.ImageUrl).ToList()
            };
        }
    }

}
