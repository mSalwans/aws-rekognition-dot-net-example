using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using rekognition.service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace rekognition.service.Implementation
{
    public class ImageToText : IImageToText
    {
        private AmazonRekognitionClient rekognitionClient;
        public DetectTextResponse detectTextResponse;

        public ImageToText(AmazonRekognitionClient rekognitionClient)
        {
            this.rekognitionClient = rekognitionClient;
        }

        public async Task<DetectTextResponse> ConvertToTextAsync(MemoryStream data)
        {
            try { 

                DetectTextRequest detectTextRequest = new DetectTextRequest()
                {
                    Image = new Image() { Bytes = data }
                };

                return await rekognitionClient.DetectTextAsync(detectTextRequest);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new DetectTextResponse();
            }
        }
    }
}
