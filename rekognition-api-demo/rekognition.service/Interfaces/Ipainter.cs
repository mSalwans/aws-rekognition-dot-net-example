using System.Drawing;

namespace rekognition.service.Interfaces
{
    public interface IPainter
    {
        Image DrawOnImage(Image image, string fileName, float height, float width,
            float top, float left, Color color);
    }
}
