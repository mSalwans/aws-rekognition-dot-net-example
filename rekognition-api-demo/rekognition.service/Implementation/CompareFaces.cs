using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using rekognition.service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace rekognition.service
{
    public class CompareFaces: ICompareFaces
    {
        private AmazonRekognitionClient rekognitionClient;
        private float similarityThreshold = 70F;

        public CompareFaces(AmazonRekognitionClient rekognitionClient)
        {
            this.rekognitionClient = rekognitionClient;
        }

        public async Task<CompareFacesResponse> CompareAsync(MemoryStream srcImg, MemoryStream trgtImg)
        {
            try
            {
                var sourceImg = new Image() { Bytes = srcImg };
                var targetImg = new Image() { Bytes = trgtImg };

                var request = new CompareFacesRequest()
                {
                    SimilarityThreshold = similarityThreshold,
                    SourceImage = sourceImg,
                    TargetImage = targetImg
                };

                return await rekognitionClient.CompareFacesAsync(request);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            return null;
        }



    }
}
