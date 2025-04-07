//using ASOS.DAL;
//using ASOS.DAL.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace ASOS.APIs.Controllers
//{
//    public class BrandController : BaseController<Brand>
//    {
//        public BrandController(IUnitOfWork unitOfWork) : base(unitOfWork)
//        {
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAllBrands()
//        {
//            return await GetAllAsync();
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetBrand(Guid id)
//        {
//            return await GetByIdAsync(id);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateBrand(Brand brand)
//        {
//            return await CreateAsync(brand);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateBrand(Guid id, Brand brand)
//        {
//            return await UpdateAsync(id, brand);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteBrand(Guid id)
//        {
//            return await DeleteAsync(id);
//        }

//        protected override Guid GetEntityId(Brand entity)
//        {
//            return entity.Id;
//        }
//    }
//} 