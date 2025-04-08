using ASOS.BL.DTOs;
using ASOS.DAL.Models;
using ASOS.DAL;
using ASOS.BL.Helpers;
using Microsoft.Extensions.Configuration;

namespace ASOS.BL.Managers.ProductImages
{
    public class ProductImagesManager : IProductImagesManager
    {
        private readonly IProductImageRepository _repository;
        private readonly string _apiBaseUrl;

        public ProductImagesManager(IProductImageRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _apiBaseUrl = configuration["ApiBaseUrl"];
        }

        private string GetFullImageUrl(string relativePath)
        {
            return string.IsNullOrEmpty(relativePath) ? null : $"{_apiBaseUrl}{relativePath}";
        }

        public async Task<IEnumerable<ProductImageDTO>> GetAllAsync()
        {
            var images = await _repository.GetAllAsync();
            return images.Select(image => new ProductImageDTO
            {
                Id = image.Id,
                ProductId = image.ProductId,
                ImageUrl = GetFullImageUrl(image.ImageUrl)
            });
        }

        public async Task<ProductImageDTO> GetByIdAsync(Guid id)
        {
            var image = await _repository.GetByIdAsync(id);
            if (image == null) return null;

            return new ProductImageDTO
            {
                Id = image.Id,
                ProductId = image.ProductId,
                ImageUrl = GetFullImageUrl(image.ImageUrl)
            };
        }

        public async Task<ProductImageDTO> CreateAsync(ProductImageCreateDTO createDto)
        {
            var relativePath = DocumentSettings.UploadFile(createDto.ImageFile);

            var entity = new ProductImage
            {
                Id = Guid.NewGuid(),
                ProductId = createDto.ProductId,
                ImageUrl = relativePath
            };

            await _repository.AddAsync(entity);

            return new ProductImageDTO
            {
                Id = entity.Id,
                ProductId = entity.ProductId,
                ImageUrl = GetFullImageUrl(entity.ImageUrl)
            };
        }

        public async Task<bool> UpdateAsync(Guid id, ProductImageUpdateDTO updateDto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            if (updateDto.ImageFile != null)
            {
                DocumentSettings.DeleteFile(entity.ImageUrl);
                entity.ImageUrl = DocumentSettings.UploadFile(updateDto.ImageFile);
            }

             _repository.Update(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            DocumentSettings.DeleteFile(entity.ImageUrl);
             _repository.Delete(entity);
            return true;
        }
    }
}
