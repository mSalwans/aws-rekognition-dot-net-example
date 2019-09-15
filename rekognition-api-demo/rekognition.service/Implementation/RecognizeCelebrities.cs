using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using rekognition.service.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace rekognition.service.Implementation
{
    public class RecognizeCelebrities: IRecognizeCelebrities
    {
        private AmazonRekognitionClient rekognitionClient;

        public RecognizeCelebrities(AmazonRekognitionClient rekognitionClient)
        {
            this.rekognitionClient = rekognitionClient;
        }

        public async Task<RecognizeCelebritiesResponse> Recognize(MemoryStream data)
        {
            try
            {
                RecognizeCelebritiesRequest request = new RecognizeCelebritiesRequest()
                {
                    Image = new Image() { Bytes = data }
                };

                return await rekognitionClient.RecognizeCelebritiesAsync(request);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new RecognizeCelebritiesResponse();
            }
        }


    }
}
