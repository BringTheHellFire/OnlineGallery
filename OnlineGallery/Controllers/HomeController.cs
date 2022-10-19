﻿using Microsoft.AspNetCore.Mvc;
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
            APIArtwork artwork = await GetArtworkById();
            APIArtworkWithPagination artworkList = await GetAllArtworks();
            return View(artworkList);
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

        public async Task<APIArtwork> GetArtworkById()
        {
            var url = string.Format("https://api.artic.edu/api/v1/artworks/129884?fields=title,image_id");
            var result = new APIArtwork();
            client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<APIArtwork>(stringResponse, new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
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

    }
}