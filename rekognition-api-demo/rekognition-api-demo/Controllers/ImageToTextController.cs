using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Rekognition.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rekognition.service.Interfaces;
using rekognition_api_demo.Helpers;

namespace rekognition_api_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageToTextController : ControllerBase
    {
        private IImageToText _imageToText;

        public ImageToTextController(IImageToText imageToText)
        {
            _imageToText = imageToText;
        }


        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadAsync(IFormFile[] imgs)
        {
            try
            {
                var file = Request.Form.Files[0];
                var stream = ImageHelper.ConvertFormFileToMemoryStream(file);
                if (stream != null)
                {
                    DetectTextResponse response;

                    response = await _imageToText.ConvertToTextAsync(stream);

                    return Ok(new { response });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}