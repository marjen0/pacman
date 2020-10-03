using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Services
{
    class API
    {
        private const string API_BASE = "https://localhost:44394/api";
        private HttpClient _httpClient;

        public API()
        {
            _httpClient = new HttpClient();
        }
        public async void CreatePlayer(Player p)
        {
            DataAccessLayer.Models.Player player = new DataAccessLayer.Models.Player();
            player.Id = p.Id;
            player.Name = p.Name;
            player.Lives = p.Lives;
            player.Score = p.Score;
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync(API_BASE + "/players", player);
            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
