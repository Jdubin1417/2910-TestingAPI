using System.Text.Json;
using TestingAPI;
// http://127.0.0.1:8000


HttpClient client = new HttpClient();

var name = "Jack";
var age = 58;

//HttpResponseMessage response = await client.GetAsync
//    ($"http://127.0.0.1:8000/user/?name={name}&age={age}");

HttpResponseMessage response = await client.GetAsync
    ($"http://127.0.0.1:8000/users");
Console.WriteLine(response + "\n");




string json = await response.Content.ReadAsStringAsync();
Console.WriteLine(json);

var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

//var user = JsonSerializer.Deserialize<User>(json, options);
//Console.WriteLine($"The user's name is {user.Name} and they are {user.Age} years old.");

var users = JsonSerializer.Deserialize<User[]>(json, options);

foreach (var u in users) Console.WriteLine(u.Name);