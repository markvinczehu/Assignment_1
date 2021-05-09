using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HandlePeopleWithLogIn.Models;

namespace HandlePeopleWithLogIn.Data {
    public class UserService : IUserService {
        private const string uri = "https://localhost:5003/Users";
        private readonly HttpClient client;
        private User logged;
        public UserService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            }; 
            client = new HttpClient(clientHandler);
        }
    
        public async Task<User> ValidateUser(string username, string password)
        {
            HttpResponseMessage response = await client.GetAsync(uri + $"?username={@username}&password={@password}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.ReasonPhrase}");
            }
            string result = await response.Content.ReadAsStringAsync();
            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            logged = user;
            return user;
        }

        public async Task AddUser(User user)
        {
            var userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri, content);
        }
    }
}