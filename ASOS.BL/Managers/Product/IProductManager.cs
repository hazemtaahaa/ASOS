using ASOS.BL.DTOs;

namespace ASOS.BL.Managers.Product
{
    public interface IProductManager
    {
        Task<List<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetByIdAsync(Guid Id);
    }
}
