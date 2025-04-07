using ASOS.BL;
using ASOS.BL.DTOs;
using ASOS.BL.DTOs.Common;
using ASOS.BL.Managers.Category;
using Microsoft.AspNetCore.Mvc;

namespace ASOS.APIs.Controllers.Woman
{
    [Route("api/[controller]")]
    [ApiController]
    public class WomanController : ControllerBase
    {
        private readonly IWomanManager _womanManager;
        private readonly ICategoryManager _categoryManager;

        public WomanController(IWomanManager womanManager ,ICategoryManager categoryManager)
        {
            _womanManager = womanManager;
            _categoryManager = categoryManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _womanManager.GetAllAsync();
            return Ok(new GeneralResult<List<ProductDTO>>() { Data = products,Success = true, Errors = [] });
        }

        [HttpGet("newin")]
        public async Task<IActionResult> GetNewInWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var newInProducts = products.OrderByDescending(p => p.CreatedAt).Take(16).ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = newInProducts, Success = true, Errors = [] });
        }

        [HttpGet("clothing")]
        public async Task<IActionResult> GetClothingWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.CategoryName == "Clothing").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

    }
}
