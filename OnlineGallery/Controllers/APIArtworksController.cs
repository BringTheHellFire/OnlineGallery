using Microsoft.AspNetCore.Mvc;
using OnlineGallery.Models;
using System.Diagnostics;
using System.Text.Json;

namespace OnlineGallery.Controllers
{
    public class APIArtworksController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            APIArtwork artwork = await GetArtworkById();
            APIArtworkWithPagination artworkList = await GetAllArtworks();
            APIArtworkWithPagination artworkList2 = await GetNextPage(artworkList.Pagination.next_url);
            return View(artworkList);
        }
        private HttpClient client;

        public async Task<APIArtwork> GetArtworkById()
        {
            var url = string.Format("https://api.artic.edu/api/v1/artworks/129884?fields=title,image_id");
            var result = new APIArtwork();
            client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<APIArtwork>(stringResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }

        public async Task<APIArtworkWithPagination> GetAllArtworks()
        {
            var url = string.Format("https://api.artic.edu/api/v1/artworks");
            var result = new APIArtworkWithPagination();
            client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<APIArtworkWithPagination>(stringResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }

        public async Task<APIArtworkWithPagination> GetNextPage(string url)
        {
            var result = new APIArtworkWithPagination();
            client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<APIArtworkWithPagination>(stringResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
