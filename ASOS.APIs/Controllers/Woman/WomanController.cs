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

        [HttpGet("clothing/dresses")]
        public async Task<IActionResult> GetDressesWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Dresses").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("clothing/blouses")]
        public async Task<IActionResult> GetBlousesWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Blouses").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("clothing/coats&jackets")]
        public async Task<IActionResult> GetJacketsWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Jackets" || p.ProductTypeName == "Coats").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("clothing/hoodies&sweatshirts")]
        public async Task<IActionResult> GetJeansWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Hoodies" || p.ProductTypeName == "Sweatshirts").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("shoes")]
        public async Task<IActionResult> GetShoesWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.CategoryName == "Shoes").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("shoes/trainers")]
        public async Task<IActionResult> GetTrainersWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Trainers").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("shoes/boots")]
        public async Task<IActionResult> GetBootsWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Boots").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("shoes/loafers")]
        public async Task<IActionResult> GetLoafersWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Loafers").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("shoes/heels")]
        public async Task<IActionResult> GetHeelsWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Heels").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("accessories")]
        public async Task<IActionResult> GetAccessoriesWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.CategoryName == "Accessories").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("accessories/sunglasses")]
        public async Task<IActionResult> GetSunglassesWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Sunglasses").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("accessories/hats")]
        public async Task<IActionResult> GetHatsWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Hats").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("accessories/gloves")]
        public async Task<IActionResult> GetGlovesWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Gloves").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("accessories/Scarves")]
        public async Task<IActionResult> GetScarvesWomenProducts()
        {
            var products = await _womanManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Scarves").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }
    }
}
