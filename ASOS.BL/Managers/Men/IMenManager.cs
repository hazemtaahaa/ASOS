using ASOS.BL.DTOs;
namespace ASOS.BL;

public interface IMenManager
    {
        Task<List<ProductDTO>> GetAllAsync();
        Task<List<BrandDTO>> GetAllBrandsAsync();
     }
