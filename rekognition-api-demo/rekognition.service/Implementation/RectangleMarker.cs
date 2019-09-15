using rekognition.service.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace rekognition.service.Implementation
{
    public class RectangleMarker : IPainter
    {
        public Image DrawOnImage(Image image, string fileName, 
            float height, float width, float top, float left, Color color)
        {
            Graphics gr = Graphics.FromImage(image);

            left = left * image.Width;
            top = top * image.Height;
            width = width * image.Width;
            height = height * image.Height;

            var imageRectangle = new Rectangle(
                Convert.ToInt32(left), Convert.ToInt32(top),
                Convert.ToInt32(width), Convert.ToInt32(height));

            Pen pen = new Pen(color, 2);

            gr.DrawRectangle(pen, left, top, width, height);
            var g = gr.ToString();

            gr.Save();
            image.Save(fileName, ImageFormat.Jpeg);

            return image;
        }
    }
}
