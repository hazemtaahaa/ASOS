using ASOS.BL;
using ASOS.BL.DTOs;
using ASOS.BL.DTOs.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASOS.APIs.Controllers.Men
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenController : ControllerBase
    {
        private readonly IMenManager _menManager;

        public MenController(IMenManager menManager)
        {
            _menManager = menManager;
        }

        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            return Ok(new GeneralResult<List<ProductDTO>>() { Errors = [],Data= await _menManager.GetAllAsync(),Success=true });
        }
    }
} 