using ASOS.BL.DTOs;

namespace ASOS.BL;

public interface IWomanManager
{
    Task<List<ProductDTO>> GetAllAsync();

    Task<List<BrandDTO>> GetAllBrandsAsync();
}
