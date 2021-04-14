using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HandlePeopleWithLogIn.Models;

namespace HandlePeopleWithLogIn.Data
{
    public class CloudService : ICloudService
    {
        private const string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public CloudService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Adult>> GetAdultAsync()
        {
            var stringAsync = await client.GetStringAsync(uri + "/adults");
            IList<Adult> result = JsonSerializer.Deserialize<IList<Adult>>(stringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            var adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri + "/adults", content);
            return adult;
        }

        public async Task RemoveAdultAsync(int Id)
        {
            await client.DeleteAsync($"{uri}/adults/{Id}");
        }

        public async Task<Adult> UpdateAdultAsync(Adult adult)
        {
            var adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync($"{uri}/adults/{adult.Id}", content);
            return adult;
        }

        public async Task<Adult> GetAsync(int Id)
        {
            var adultAsJson = await client.GetStringAsync($"{uri}/adults/{Id}");
            Adult adult = JsonSerializer.Deserialize<Adult>(adultAsJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return adult;
        }
    }
}