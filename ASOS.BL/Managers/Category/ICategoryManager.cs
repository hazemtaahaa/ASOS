using ASOS.BL.DTOs;

namespace ASOS.BL.Managers.Category
{
    public interface ICategoryManager
    {
        Task<List<CategoryDTO>> GetAllAsync();

        Task<CategoryDTO> GetByIdAsync(Guid id);

        Task<CategoryDTO> GetByNameAsync(string name);



    }
}
