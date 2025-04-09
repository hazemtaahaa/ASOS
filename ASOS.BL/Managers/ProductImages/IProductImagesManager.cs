using ASOS.BL.DTOs;

namespace ASOS.BL.Managers.ProductImages
{
    public interface IProductImagesManager
    {
        Task<IEnumerable<ProductImageDTO>> GetAllAsync();
        Task<ProductImageDTO> GetByIdAsync(Guid id);
        Task<ProductImageDTO> CreateAsync(ProductImageCreateDTO createDto);
        Task<bool> UpdateAsync(Guid id, ProductImageUpdateDTO updateDto);
        Task<bool> DeleteAsync(Guid id);
    }

}
