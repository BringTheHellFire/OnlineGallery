﻿using Microsoft.AspNetCore.Mvc;
using OnlineGallery.Models;
using System.Diagnostics;
using System.Text.Json;

namespace OnlineGallery.Controllers
{
    public class APIArtworksController : Controller
    {
        private HttpClient client;
        public async Task<IActionResult> IndexAsync()
        {
            APIArtworkWithPagination artworkList = await GetAllArtworks();
            return View(artworkList);
        }

        public async Task<IActionResult> AgentAsync()
        {
            APIAgentWithPagination agent = await GetAnAgent();
            return View(agent);
        }


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

        public async Task<IActionResult> GoNextPage(int number)
        {
            var artworks = await this.GetNextPage(number);
            return View("Index", artworks);
        }

        public async Task<APIArtworkWithPagination> GetNextPage(int number)
        {
            var result = new APIArtworkWithPagination();
            client = new HttpClient();
            var url = "https://api.artic.edu/api/v1/artworks?page=" + number.ToString();
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

        public async Task<APIAgentWithPagination> GetAnAgent()
        {
            var result = new APIAgentWithPagination();
            client = new HttpClient();
            var url = string.Format("https://api.artic.edu/api/v1/agents");
            
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<APIAgentWithPagination>(stringResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
