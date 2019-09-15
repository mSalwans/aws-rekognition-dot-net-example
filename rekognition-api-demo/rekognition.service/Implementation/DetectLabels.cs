using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using rekognition.service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace rekognition.service
{
    public class DetectLabels: IDetectLabels
    {
        private AmazonRekognitionClient rekognitionClient;
        private DetectLabelsRequest detectlabelsRequest;

        public DetectLabels(AmazonRekognitionClient rekognitionClient)
        {
            this.rekognitionClient = rekognitionClient;
        }

        public async Task<DetectLabelsResponse> DetectAsync(MemoryStream data)
        {
            try
            {
                var image = new Image() { Bytes = data };

                detectlabelsRequest = new DetectLabelsRequest()
                {
                    Image = image,
                    MaxLabels = 10,
                    MinConfidence = 77F
                };

                return await rekognitionClient.DetectLabelsAsync(detectlabelsRequest);
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new DetectLabelsResponse();
            }

        }



    }
}
