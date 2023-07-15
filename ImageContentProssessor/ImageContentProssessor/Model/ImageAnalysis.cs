using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Reflection;

namespace ImageContentProssessor.Model
{
    public class ImageAnalysis
    {
        public required string Url { get; set; }
        public List<ImageCaption?> Captions { get; set; }
        public List<ImageTag?> Tags { get; set; }
        public ImageType? ImageType { get; set; }
        public List<FaceDescription>? Faces { get; set; }
    }
}
