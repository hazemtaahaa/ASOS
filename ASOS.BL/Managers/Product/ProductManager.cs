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

        public async Task<ProductDTO> CreateAsync(ProductCreateDTO product)
        {
            var productDb = new DAL.Models.Product()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Section = product.Section,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                ProductTypeId = product.ProductTypeId,
            };
             _unitOfWork.Products.AddAsync(productDb);
            await _unitOfWork.CompleteAsync();

            return new ProductDTO
            {
                Name = productDb.Name,
                Description = productDb.Description,
                Price = (decimal)productDb.Price,
                Quantity = (int)productDb.Quantity,
                Section = productDb.Section,
                BrandName = productDb.Brand.Name,
                CategoryName = productDb.Category.Name,
                ProductTypeName = productDb.ProductType.Name,
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var productDb = await _unitOfWork.Products.GetByIdAsync(id);
            if (productDb == null)
            {
                return false;
            }
            _unitOfWork.Products.Delete(productDb);
            await _unitOfWork.CompleteAsync();
            return true;
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

        public async Task<bool> UpdateAsync(Guid id, ProductUpdateDTO product)
        {
            var productDb = await _unitOfWork.Products.GetByIdAsync(id);
            if (productDb == null)
            {
                return false;
            }
            productDb.Name = product.Name;
            productDb.Description = product.Description;
            productDb.Price = product.Price;
            productDb.Quantity = product.Quantity;
            productDb.Section = product.Section;
            productDb.BrandId = product.BrandId;
            productDb.CategoryId = product.CategoryId;
            productDb.ProductTypeId = product.ProductTypeId;
            productDb.UpdatedAt = DateTime.Now;

            _unitOfWork.Products.Update(productDb);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }

}
