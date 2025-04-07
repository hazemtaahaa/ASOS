using ASOS.BL.DTOs;
using ASOS.BL.Managers.Woman;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASOS.APIs.Controllers.Woman
{
    [Route("api/[controller]")]
    [ApiController]
    public class WomanController : ControllerBase
    {
        private readonly IWomanManager _womanManager;

        public WomanController(IWomanManager womanManager)
        {
            _womanManager = womanManager;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAll()
        {
            
            return await _womanManager.GetAllAsync();
        }
    }
}
