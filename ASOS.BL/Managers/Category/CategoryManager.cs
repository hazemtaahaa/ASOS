using ASOS.BL.DTOs;
using ASOS.DAL;

namespace ASOS.BL.Managers.Category
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            var categoriesFromDB = await _unitOfWork.Categories.GetAllAsync();
            return  categoriesFromDB.Select(d => new CategoryDTO
            {
                Id = d.Id,
                Name = d.Name, 
            }).ToList();
        }
        public async Task<CategoryDTO> GetByIdAsync(Guid id)
        {
            var categoryFromDB = await _unitOfWork.Categories.GetByIdAsync(id);

            return new CategoryDTO() { Id = categoryFromDB.Id,Name = categoryFromDB.Name};
        }
        public async Task<CategoryDTO> GetByNameAsync(string name)
        {
            var categoryFromDB= await _unitOfWork.Categories.GetByNameAsync(name);
            return new CategoryDTO() { Id = categoryFromDB.Id, Name = categoryFromDB.Name };
        }
    }
    
}
