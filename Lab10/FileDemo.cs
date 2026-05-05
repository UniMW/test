namespace Lab10;

public class FileDemo
{
    public static void Run()
    {
        var f = Load("D:/Users/marcel.wojdat/RiderProjects/ProgramowanieObiektowe26/public/data.txt.txt");
        Console.WriteLine(f.Result);
        while (Console.ReadKey().Key != ConsoleKey.Escape)
        {
            
        }
    }

    public static async Task<string> Load(string path)
    {
        var text = await File.ReadAllTextAsync(path);
        return text.ToUpper();
    }
}