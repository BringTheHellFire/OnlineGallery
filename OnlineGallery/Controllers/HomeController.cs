using Microsoft.AspNetCore.Mvc;
using OnlineGallery.Models;
using System.Diagnostics;
using System.Text.Json;

namespace OnlineGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            _ = await GetAllAPIArtworks();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private HttpClient client;

        public async Task<APIArtwork> GetAllAPIArtworks()
        {
            var url = string.Format("https://api.artic.edu/api/v1/artworks/129884?fields=title");
            var result = new APIArtwork();
            client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                var unknownObject = JsonDocument.Parse(stringResponse);
                JsonElement productName = unknownObject.RootElement.GetProperty("data");
                var title = productName.Deserialize<APIArtwork>();

                result = JsonSerializer.Deserialize<APIArtwork>(stringResponse, new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

                _ = result.Data;
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}