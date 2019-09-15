using Amazon.Rekognition.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace rekognition.service.Interfaces
{
    public interface IDetectLabels
    {
        Task<DetectLabelsResponse> DetectAsync(MemoryStream data);
    }
}
