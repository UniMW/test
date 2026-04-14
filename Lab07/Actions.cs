namespace Lab07;

public class Actions
{
    public static void ActionDemo()
    {
        Action<string> hello = HelloWorld;
        Action<int> prntsquare = PrintSquare;
        Action<string, int, bool> save = Save;
        
    }

    public static void Save(string filename, int count, bool isOpen)
    {
        Console.WriteLine("Saving file");
    }

    public static void HelloWorld(string s)
    {
        Console.WriteLine($"Hello {s}");
    }

    public static void PrintSquare(int x)
    {
        Console.WriteLine(x * x);
    }
}