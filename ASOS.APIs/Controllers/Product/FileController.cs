using ASOS.BL.DTOs.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASOS.APIs.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(GeneralResult<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            var extention = Path.GetExtension(file.FileName);

            #region Check If Null
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            #endregion

            #region Checking Extention
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            bool isExtensionAllowed = allowedExtensions.Contains(extention, StringComparer.InvariantCultureIgnoreCase);

            if (!isExtensionAllowed)
            {
                return BadRequest("Invalid file type. Only .jpg, .jpeg, .png, and .gif files are allowed.");
            }
            #endregion

            #region Storing The Image

            var newFileName = Guid.NewGuid() + extention;

            var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            
            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }

            var filePath = Path.Combine(imagesPath, newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileUrl = $"{Request.Scheme}://{Request.Host}/Images/{newFileName}";

            return Ok(new GeneralResult<string>() { Data = fileUrl, Success = true, Errors = [] });
            #endregion
        }
    }
}
