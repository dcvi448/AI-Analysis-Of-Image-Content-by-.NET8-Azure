using Microsoft.Extensions.Configuration;

namespace ImageContentProssessor.Services
{
    public class ImageProcessorService
    {
        private readonly IConfiguration _configuration;

        public ImageProcessorService(IConfiguration configuration)
        {
            _configuration = configuration;
        } 
    }
}
