using System.Text.Json;

namespace Lab10;

public record Todo(int Id, string Title, int UserId, bool Completed);
public record Post(int Id, string Title, int UserId, string Body);
public record User(int Id, string Name, string Username, string Email, Address Address, string Phone, string Website, Company Company);
public record Company(string Name, string CatchPhrase, string Bs);
public record Address(string Street, string Suite, string City, string Zipcode, Geo Geo);
public record Geo(double Latitude, double Longitude);


public class SerializeDemo
{
    
    public static void RunDeserializeUsers()
    {
        HttpClient client = new HttpClient();
        var response = client.GetStringAsync("https://jsonplaceholder.typicode.com/users").Result;
        List<User> users = JsonSerializer.Deserialize<List<User>>(response, new  JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var res = users
            .Where(u => u.Id == 1)
            .ToList();
        Console.WriteLine(string.Join("\n", res));
    }
    
    public static void RunDeserializeAll()
    {
        HttpClient client = new HttpClient();
        var response = client.GetStringAsync("https://jsonplaceholder.typicode.com/todos").Result;
        List<Todo> todos = JsonSerializer.Deserialize<List<Todo>>(response, new  JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var res = todos
            .Where(c => c.UserId == 2 && c.Completed)
            .ToList();
        Console.WriteLine(string.Join("\n", res));
    }
    
    public static void RunDeserializePosts()
    {
        HttpClient client = new HttpClient();
        var response = client.GetStringAsync("https://jsonplaceholder.typicode.com/posts").Result;
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(response, new  JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var res = posts
            .Where(c => c.UserId == 2)
            .Select(c => new
            {
                Tytul = c.Title,
                Tresc = c.Body,
            })
            .ToList();
        Console.WriteLine(string.Join("\n", res));
    }
    
    public static void RunDeserialize()
    {
        HttpClient client = new HttpClient();
        var response = client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/3").Result;
        var todo = JsonSerializer.Deserialize<Todo>(response);
        Console.WriteLine(todo);
    }

    public static void RunSerialize()
    {
        Todo todo = new Todo(1, "posprzatac", 4, false);
        var output = JsonSerializer.Serialize(todo, JsonSerializerOptions.Default);
        Console.WriteLine(output);
        List<Todo> todos = new()
        {
            todo,
            new Todo(2, "umyc naczynia", 3, false),
            new Todo(3, "Ogarnac w domyu", 4, false)
        };
        var todosOutput = JsonSerializer.Serialize(todos, JsonSerializerOptions.Default);
        Console.WriteLine(todosOutput);

    }
}