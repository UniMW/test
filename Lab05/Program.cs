using System.Globalization;
using System.Security.Cryptography;

namespace Lab05;

public record StudentDegree(Degree degree, string StudentName);

public record Point
{
    public required double X { get; set; }
    public required double Y { get; set; }

    public Point MoveX(int delta)
    {
        return new Point()
        {
            X = X + delta,
            Y = Y
        };
    }
    public Point MoveY(int delta)
    {
        return new Point()
        {
            X = X,
            Y = delta + Y
        };
    }
}
class Program
{
    public static void PointDemo()
    {
        Point p1 = new Point() {X = 1, Y = 2};
        Point p2 = new Point() {X = 3, Y = 6};
        Console.WriteLine(p1);
        Console.WriteLine(p2);
        p1.MoveX(2);
        Console.WriteLine(p1.X);
    }
    public static void RecordDemo()
    {
        StudentDegree sd1 = new StudentDegree(Degree.BARDZO_DOBRY, "Adam");
        StudentDegree sd2 = new StudentDegree(Degree.NIEDOSTATECZNY, "Kasia");
        Console.WriteLine(sd1 == sd2);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Wpisz ocenę: ");
        var names = Enum.GetNames<Degree>();
        Console.WriteLine(string.Join(", ", names));
        string? degreeStr = Console.ReadLine();
        Degree degree;
        while (!Enum.TryParse<Degree>(degreeStr?.ToUpper() ?? "", out degree))
        {
            Console.WriteLine("Nieznana ocena! Prosze podac jeszcze raz");
            degreeStr = Console.ReadLine();
        }
        Degree d = Degree.BARDZO_DOBRY;
        Console.WriteLine((int) d);
        Console.WriteLine((int) degree);
        Console.WriteLine($"Srednia ocen {((int) d + (int) degree) / 20.0}");
    }

    public static void SwitchDemo()
    {
        Console.WriteLine("Wpisz ocenę: ");
        var names = Enum.GetNames<Degree>();
        Console.WriteLine(string.Join(", ", names));
        string? degreeStr = Console.ReadLine();
        Degree degree;
        while (!Enum.TryParse<Degree>(degreeStr?.ToUpper() ?? "", out degree))
        {
            Console.WriteLine("Nieznana ocena! Prosze podac jeszcze raz");
            degreeStr = Console.ReadLine();
        }
        Degree d = Degree.BARDZO_DOBRY;
        Console.WriteLine((int) d);
        Console.WriteLine((int) degree);
        Console.WriteLine($"Srednia ocen {((int) d + (int) degree) / 20.0}");

        string englishDegree = degree switch
        {
            Degree.BARDZO_DOBRY => "A",
            Degree.DOBRY_PLUS => "B",
            Degree.DOBRY => "C",
            Degree.DOSTATECZNY_PLUS => "D",
            Degree.DOSTATECZNY => "E",
            Degree.NIEDOSTATECZNY => "F",
            _ => throw new ArgumentOutOfRangeException(nameof(degree), degree, null)
        };
        Console.WriteLine(englishDegree);
    }

    public static void Task01()
    {
        Console.WriteLine("Wpisz nr miesiaca");
        int month = int.Parse(Console.ReadLine());
        string Season = month switch
        {
            12 or 1 or 2 => "Zima",
            3 or 4 or 5 => "Wiosna",
            6 or 7 or 8 => "Lato",
            9 or 10 or 11 => "Jesien",
            _ => "Nieznany miesiac"
        };
        Console.WriteLine(Season);
    }

    
}

public enum Degree
{
    NIEDOSTATECZNY = 20,
    DOSTATECZNY = 30,
    DOSTATECZNY_PLUS = 35,
    DOBRY = 40,
    DOBRY_PLUS = 45,
    BARDZO_DOBRY = 50
}
public static class DegreeExtensions
{
    public static double Value(this Degree degree)
    {
        return degree switch
        {
            Degree.NIEDOSTATECZNY => 2.0,
            Degree.DOSTATECZNY => 3.0,
            Degree.DOSTATECZNY_PLUS => 3.5,
            Degree.DOBRY => 4.0,
            Degree.DOBRY_PLUS => 4.5,
            Degree.BARDZO_DOBRY => 5.0,
            _ => throw new ArgumentOutOfRangeException(nameof(degree), degree, null)
        };
    }

    public static string ToEnglish(this Degree degree)
    {
        return degree switch
        {
            Degree.NIEDOSTATECZNY => "F",
            Degree.DOSTATECZNY => "E",
            Degree.DOSTATECZNY_PLUS => "D",
            Degree.DOBRY => "C",
            Degree.DOBRY_PLUS => "B",
            Degree.BARDZO_DOBRY => "A",
            _ => throw new ArgumentOutOfRangeException(nameof(degree), degree, null)
        };
    }
}


