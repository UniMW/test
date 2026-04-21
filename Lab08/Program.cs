using System.Net.WebSockets;

namespace Laa08;

public record Product
{
    public int Index { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
}

public record Student(int Id, string Name, int Ects);

class Program
{
    public static IEnumerable<Product> ReadFromFiles(string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        foreach (var line in lines)
        {
            if (line.StartsWith("Index"))
            {
                continue;
            }
            var tokens = line.Split(',');
            var product = new Product()
            {
                Index = int.Parse(tokens[0]),
                Name = tokens[1],
                Description = tokens[2].Contains('"')?line.Substring(
                    line.IndexOf('"') + 1, Math.Max(0, line.LastIndexOf('"') - line.IndexOf('"') - 1)): tokens[2],
            };
            yield return product;
        }
        
    }

    public static IEnumerable<Student> ReadStudents(string fileName)
    {
        return File.ReadAllLines(fileName)
            .ToList()
            .Select(l =>
            {
                var tokens = l.Split('\t');
                return new Student(
                    int.Parse(tokens[0]),
                    tokens[1],
                    int.Parse(tokens[2]));
            });
    }

    public static void StudentDemo()
    {
        var students = ReadStudents(@"D:\Users\marcel.wojdat\RiderProjects\ProgramowanieObiektowe26\public\data.txt");
        Console.WriteLine($"Suma ECTS: {students.Sum(s => s.Ects)}");
    }

    static void Main(string[] args)
    {
        var products = ReadFromFiles(@"D:\Users\marcel.wojdat\RiderProjects\ProgramowanieObiektowe26\public\Products-100000.csv");
        var filtered = products.Where(p=> p.Name.ToLower().Contains("speaker"));
        var filtered5 = products.Where(p=> p.Name.Length == 5);
        var filteredNull = products.Where(p=> p.Description == string.Empty);
        Console.WriteLine(filtered5.Count());
        Console.WriteLine(filteredNull.Count());
        var names = products.Select(p => p.Name.ToUpper());
        var indexes = products.Select(p => p.Index);
        names = names.Take(500);
        indexes = indexes.Skip(500).Take(200);
        // indexes.ToList().ForEach(n => Console.WriteLine(n));
        
        var product = products.FirstOrDefault(p => p.Index == 456);
        Console.WriteLine("Znaleziony produkt: " + product);
        bool all = products.All(p => p.Name.Length >= 3);
        Console.WriteLine("Czy maja co najmniej 3 znaki: " + all);
        bool any = products.All(p => p.Name.Length > 50);
        Console.WriteLine("Czy maja co najmniej 50 znakow: " + any);
        
        products.
            OrderBy(p => p.Name)
            .Take(100)
            .ToList().
            ForEach(p => Console.WriteLine(p));
    }
}