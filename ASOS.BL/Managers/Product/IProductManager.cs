using ASOS.BL.DTOs;

namespace ASOS.BL.Managers.Product
{
    public interface IProductManager
    {
        Task<List<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetByIdAsync(Guid Id);
        Task<ProductDTO> CreateAsync(ProductCreateDTO product);
        Task<bool> UpdateAsync(Guid id, ProductUpdateDTO product);
        Task<bool> DeleteAsync(Guid id);
    }
}
