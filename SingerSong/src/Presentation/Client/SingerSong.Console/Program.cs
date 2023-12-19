using SingerSong.Console.Models.AlbumModels;
using SingerSong.Console.Models.AuthModels;
using SingerSong.Console.Services.Contrats;
using System.Net.Http.Json;
using System.Text.Json;

//Console.WriteLine("--------------------- Login -----------------");
//Console.Write("Email:");
//string email = Console.ReadLine();
//Console.Write("Password:");
//string password = Console.ReadLine();

//LoginRequet loginRequet = new(email, password);

//UserService userService = new();
//string ApiKey = userService.Login(loginRequet).Result;
//Console.WriteLine($"API Key: {ApiKey}");

const string Url = "http://localhost:5041/api/Albums";
HttpClient client = new();

//client.DefaultRequestHeaders.Add("Authentication", "Bearer " + ApiKey);
HttpResponseMessage response = await client.GetAsync(Url);
var albums = await response.Content.ReadFromJsonAsync<IEnumerable<GetAlbumsResponse>>();
foreach (var album in albums.DistinctBy(x=>x.singerName))
{
    Console.WriteLine(album.singerName);
}

