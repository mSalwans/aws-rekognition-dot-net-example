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
using System.Drawing;

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
            IPainter painter = new rekognition.service.Implementation.RectangleMarker();

            try
            {
                var file = Request.Form.Files[0];
                var stream = ImageHelper.ConvertFormFileToMemoryStream(file);
                if (stream != null)
                {
                    var response = new DetectLabelsResponse();

                    response = await _detectLabels.DetectAsync(stream);

                    string markedImg = "";

                    if (response.Labels.Count > 0)
                    {
                        System.Drawing.Image output = System.Drawing.Image.FromStream(stream);

                        foreach (Label box in response.Labels)
                        {
                            foreach (Instance instance in box.Instances)
                            {
                                var boundingBox = instance.BoundingBox;
                                output = painter.DrawOnImage(output, file.FileName,
                                    boundingBox.Height, boundingBox.Width,
                                    boundingBox.Top, boundingBox.Left, GetRandomColor());
                            }
                        }

                        markedImg = ImageHelper.ConvertImageToBase64(output);
                    }


                    return Ok(new { response, markedImg });
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

        private Color GetRandomColor()
        {
            Random r = new Random();
            return Color.FromArgb(r.Next(0, 256), r.Next(0, 256), 0);
        }


    }
}