using System;
using System.Collections.Generic;
using System.IO;
using Amazon.Rekognition.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rekognition.service;
using rekognition_api_demo.Helpers;
using Microsoft.Extensions.Configuration;
using rekognition.service.Interfaces;

namespace rekognition_api_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetectLabelsController : ControllerBase
    {
        private IDetectLabels _detectLabels;
        public DetectLabelsController(IDetectLabels detectLabels)
        {
            _detectLabels = detectLabels;
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
                    var response = new DetectLabelsResponse();

                    response = await _detectLabels.DetectAsync(stream);

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