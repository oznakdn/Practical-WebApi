using SingerSong.Console.Models.AuthModels;
using System.Net.Http.Json;

namespace SingerSong.Console.Services.Contrats;

internal class UserService
{
    HttpClient client;
    string autUrl = "http://localhost:5041/api/Auth/Login";
    public UserService()
    {
        client = new();
    }
    public async Task<string> Login(LoginRequet loginModel)
    {
        var response =await client.PostAsJsonAsync(autUrl, loginModel);
        if(response != null)
        {
            LoginResponse? result = response.Content.ReadFromJsonAsync<LoginResponse>().Result;
            return result.AccessToken;
        }
        return string.Empty;
    }
}

