using ASOS.DAL;
using ASOS.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASOS.APIs.Controllers
{
    public class CategoryController : BaseController<Category>
    {
        public CategoryController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return await GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            return await GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            return await CreateAsync(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, Category category)
        {
            return await UpdateAsync(id, category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            return await DeleteAsync(id);
        }

        protected override Guid GetEntityId(Category entity)
        {
            return entity.Id;
        }
    }
} 