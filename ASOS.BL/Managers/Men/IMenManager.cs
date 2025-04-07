using ASOS.BL;
using ASOS.BL.DTOs;
namespace ASOS.BL;

    public interface IMenManager
    {
        Task<List<ProductDTO>> GetAllAsync();
    }
