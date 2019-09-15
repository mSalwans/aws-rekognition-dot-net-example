using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Rekognition.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using rekognition.service;
using rekognition.service.Interfaces;
using rekognition_api_demo.Helpers;

using System.Drawing;
using System.Drawing.Drawing2D;
using rekognition.service.Implementation;

namespace rekognition_api_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompareFacesController : ControllerBase
    {
        ICompareFaces _compareFaces;

        public CompareFacesController(ICompareFaces compareFaces)
        {
            _compareFaces = compareFaces;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            IPainter painter = new RectangleMarker();
            CompareFacesResponse response;

            try
            {
                var sourceImg = Request.Form.Files[0];
                var targetImg = Request.Form.Files[1];
                var srcImg = ImageHelper.ConvertFormFileToMemoryStream(sourceImg);
                var trgtImg = ImageHelper.ConvertFormFileToMemoryStream(targetImg);

                if (sourceImg != null )// && targetImg != null)
                {
                    response = await _compareFaces.CompareAsync(srcImg, trgtImg);
                    string markedImg = "";
                    if(response.FaceMatches.Count > 0 )
                    {
                        System.Drawing.Image output = System.Drawing.Image.FromStream(trgtImg) ;

                        foreach(var box in response.FaceMatches)
                        {
                            var boundingBox = box.Face.BoundingBox;
                            output = painter.DrawOnImage(output, targetImg.FileName,
                                boundingBox.Height, boundingBox.Width,
                                boundingBox.Top, boundingBox.Left, Color.LightGreen);
                        }

                        foreach(var box in response.UnmatchedFaces)
                        {
                            var boundingBox = box.BoundingBox;
                            output = painter.DrawOnImage(output, targetImg.FileName,
                                boundingBox.Height, boundingBox.Width,
                                boundingBox.Top, boundingBox.Left, Color.Red);
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

