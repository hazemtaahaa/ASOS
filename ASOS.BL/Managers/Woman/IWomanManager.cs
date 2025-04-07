using ASOS.BL.DTOs;
using ASOS.BL.DTOs.Common;

namespace ASOS.BL.Managers.Woman
{
    public interface IWomanManager
    {
        Task<List<ProductDTO>> GetAllAsync();
    }
}
