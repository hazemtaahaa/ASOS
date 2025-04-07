//using ASOS.DAL;
//using ASOS.DAL.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace ASOS.APIs.Controllers
//{
//    public class ProductController : BaseController<Product>
//    {
//        public ProductController(IUnitOfWork unitOfWork) : base(unitOfWork)
//        {
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAllProducts()
//        {
//            return await GetAllAsync();
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetProduct(Guid id)
//        {
//            return await GetByIdAsync(id);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateProduct(Product product)
//        {
//            return await CreateAsync(product);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateProduct(Guid id, Product product)
//        {
//            return await UpdateAsync(id, product);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteProduct(Guid id)
//        {
//            return await DeleteAsync(id);
//        }

//        protected override Guid GetEntityId(Product entity)
//        {
//            return entity.Id;
//        }
//    }
//} 