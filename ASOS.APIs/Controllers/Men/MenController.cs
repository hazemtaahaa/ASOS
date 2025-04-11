using ASOS.BL;
using ASOS.BL.DTOs;
using ASOS.BL.DTOs.Common;
using ASOS.BL.Managers.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASOS.APIs.Controllers.Men
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenController : ControllerBase
    {
        private readonly IMenManager _menManager;
        private readonly ICategoryManager _categoryManager;

        public MenController(IMenManager menManager, ICategoryManager categoryManager)
        {
            _menManager = menManager;
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _menManager.GetAllAsync();
            return Ok(new GeneralResult<List<ProductDTO>>() { Data = products, Success = true, Errors = [] });
        }

        [HttpGet("newin")]
        public async Task<IActionResult> GetNewInMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var newInProducts = products.OrderByDescending(p => p.CreatedAt).Take(16).ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = newInProducts, Success = true, Errors = [] });
        }

        [HttpGet("clothing")]
        public async Task<IActionResult> GetClothingMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.CategoryName == "Clothing").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("clothing/shirts")]
        public async Task<IActionResult> GetShirtsMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Shirts").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("clothing/t-shirts")]
        public async Task<IActionResult> GetTShirtsMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "T-Shirts").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("clothing/coats&jackets")]
        public async Task<IActionResult> GetJacketsMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Jackets" || p.ProductTypeName == "Coats").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("clothing/hoodies&sweatshirts")]
        public async Task<IActionResult> GetHoodiesMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Hoodies" || p.ProductTypeName == "Sweatshirts").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("shoes")]
        public async Task<IActionResult> GetShoesMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.CategoryName == "Shoes").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("shoes/trainers")]
        public async Task<IActionResult> GetTrainersMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Trainers").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("shoes/boots")]
        public async Task<IActionResult> GetBootsMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Boots").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("shoes/loafers")]
        public async Task<IActionResult> GetLoafersMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Loafers").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("shoes/sandals")]
        public async Task<IActionResult> GetSandalsMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Sandals").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("accessories")]
        public async Task<IActionResult> GetAccessoriesMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.CategoryName == "Accessories").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("accessories/sunglasses")]
        public async Task<IActionResult> GetSunglassesMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Sunglasses").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("accessories/hats")]
        public async Task<IActionResult> GetHatsMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Hats").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("accessories/gloves")]
        public async Task<IActionResult> GetGlovesMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Gloves").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("accessories/scarves")]
        public async Task<IActionResult> GetScarvesMenProducts()
        {
            var products = await _menManager.GetAllAsync();
            var productsByCategory = products.Where(p => p.ProductTypeName == "Scarves").ToList();

            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByCategory, Success = true, Errors = [] });
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetWomanBrands()
        {
            var brands = await _menManager.GetAllBrandsAsync();
            return Ok(new GeneralResult<List<BrandDTO>>() { Data = brands, Success = true, Errors = [] });
        }

        [HttpGet("{brand}")]
        public async Task<IActionResult> GetProductsByBrand(string brand)
        {
            var products = await _menManager.GetAllAsync();
            var productsByBrand = products.Where(p => p.BrandName == brand).ToList();
            return Ok(new GeneralResult<List<ProductDTO>>() { Data = productsByBrand, Success = true, Errors = [] });
        }
    }
} 