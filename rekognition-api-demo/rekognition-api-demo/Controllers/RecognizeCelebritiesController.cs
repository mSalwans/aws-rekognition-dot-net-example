using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Rekognition.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rekognition.service.Implementation;
using rekognition.service.Interfaces;
using rekognition_api_demo.Helpers;

namespace rekognition_api_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecognizeCelebritiesController : ControllerBase
    {
        private IRecognizeCelebrities _recognizeCelibrities;

        public RecognizeCelebritiesController(IRecognizeCelebrities recognizeCelibrities)
        {
            _recognizeCelibrities = recognizeCelibrities;
        }



        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadAsync(IFormFile[] imgs)
        {
            IPainter painter = new RectangleMarker();

            try
            {
                var file = Request.Form.Files[0];
                var stream = ImageHelper.ConvertFormFileToMemoryStream(file);


                if (stream != null)
                {
                    var response = new RecognizeCelebritiesResponse();

                    response = await _recognizeCelibrities.Recognize(stream);

                    string markedImg = "";
                    if (response.CelebrityFaces.Count > 0)
                    {
                        System.Drawing.Image output = System.Drawing.Image.FromStream(stream);

                        foreach (var box in response.CelebrityFaces)
                        {
                            var boundingBox = box.Face.BoundingBox;
                            output = painter.DrawOnImage(output, file.FileName,
                                boundingBox.Height, boundingBox.Width,
                                boundingBox.Top, boundingBox.Left, Color.LightGreen);
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

    }
}