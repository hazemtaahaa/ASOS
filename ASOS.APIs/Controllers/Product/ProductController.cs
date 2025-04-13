using ASOS.BL.DTOs.Common;
using ASOS.BL.DTOs;
using ASOS.BL.Managers.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Just Comment
namespace ASOS.APIs.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {

            var product = await _productManager.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(new GeneralResult<ProductDTO>() { Data = product, Success = true, Errors = [] });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productManager.GetAllAsync();
            return Ok(new GeneralResult<List<ProductDTO>>() { Data = products, Success = true, Errors = [] });
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new GeneralResult() { Success = false, Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => new ResultError() { Message = e.ErrorMessage }).ToArray() });
            }
            var createdProduct = await _productManager.CreateAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, new GeneralResult<ProductDTO>() { Data = createdProduct, Success = true, Errors = [] });
        }
    }
}
