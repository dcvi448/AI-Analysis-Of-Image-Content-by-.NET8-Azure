using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using ImageContentProssessor.Model;
using System.Text.Encodings.Web;
using System.Net;
using Newtonsoft.Json;
using System;

namespace ImageContentProssessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageAnalyzerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ComputerVisionClient _computerVisionClient;

        public ImageAnalyzerController(IConfiguration configuration)
        {
            _configuration = configuration;
            var key = _configuration["ComputerVision:Key"];
            var endpoint = _configuration["ComputerVision:Endpoint"];
            _computerVisionClient = new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
            {
                Endpoint = endpoint,
            };
        }

        [HttpGet("{urlImage}")]
        public async Task<ActionResult<Model.ImageAnalysis>> GetImage(string urlImage)
        {
            if (string.IsNullOrEmpty(urlImage))
            {
                return NotFound();
            }

            var features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Description,
                VisualFeatureTypes.ImageType,
                VisualFeatureTypes.Faces,
                VisualFeatureTypes.Tags
            };

            var analysis = await _computerVisionClient.AnalyzeImageAsync(WebUtility.UrlDecode(urlImage), features);
            return new Model.ImageAnalysis()
            {
                Url = urlImage,
                Captions = analysis.Description.Captions.ToList(),
                ImageType = analysis.ImageType,
                Faces = analysis.Faces.ToList(),
                Tags = analysis.Tags.ToList()
            };
        }
    }
}

