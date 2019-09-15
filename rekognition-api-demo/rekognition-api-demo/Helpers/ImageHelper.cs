using Amazon.Rekognition.Model;
using Microsoft.AspNetCore.Http;
using rekognition.service.Implementation;
using rekognition.service.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace rekognition_api_demo.Helpers
{
    public class ImageHelper
    {
        public static MemoryStream ConvertFormFileToMemoryStream(IFormFile file)
        {
            if(file.Length > 0)
            {
                byte[] fileBytes = new Byte[file.Length];
                file.OpenReadStream().Read(fileBytes, 0, Int32.Parse(file.Length.ToString()));

                // create unique file name
                var fileName = Guid.NewGuid() + file.FileName;

                return new MemoryStream(fileBytes);
            }

            return null;
        }

        public static string ConvertImageToBase64(System.Drawing.Image img)
        {
            var type = img.GetType();
            var prefix = $"data:image/jpeg;base64,";
            using (MemoryStream m = new MemoryStream())
            {
                img.Save(m, img.RawFormat);
                byte[] imageBytes = m.ToArray();

                // Convert byte[] to Base64 String
                return prefix + Convert.ToBase64String(imageBytes);
            }
            
        }

    }
}
