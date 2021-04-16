using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HandlePeopleWithLogIn.Models;

namespace HandlePeopleWithLogIn.Data {
public class UserService : IUserService {
    private const string uri = "https://localhost:5003";
    private readonly HttpClient client;
    public UserService()
    {
        client = new HttpClient();
    }
    
    public async Task<User> ValidateUser(string username, string password)
    {
        HttpResponseMessage response = await client.GetAsync(uri + $"/users?username={username}&password={password}");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            string userAsJson = await response.Content.ReadAsStringAsync();
            User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
            return resultUser;
        } 
        throw new Exception("User not found");
    }

    public async Task AddUser(User user)
    {
        var userAsJson = JsonSerializer.Serialize(user);
        HttpContent content = new StringContent(userAsJson,
            Encoding.UTF8,
            "application/json");
        await client.PostAsync(uri + "/users", content);
    }
}
}