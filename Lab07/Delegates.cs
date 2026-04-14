namespace Lab07;

public class Delegates
{
    delegate double Func(double a, double b);
    public delegate bool StringPredicate(string s);
    
    
    public static void Run()
    {
        Func op = Add;
        Console.WriteLine(op(2,4));
        Func opm = Multiply;
        Console.WriteLine(opm(3,4.5));
        Func[] operators = [ Add, Subtrack, Multiply ];
        foreach (var oper in operators)
        {
            Console.WriteLine(oper(2,3));
        }
        /* Delegat jest typem funkcji, z tym samym typem zwracanym co funkcja go wywołująca ( może być anonimowa ) */
        StringPredicate pred = Prediction;
        Console.WriteLine(pred("blablabla"));
    }

    public static bool Prediction(string s)
    {
        if (s.Length > 5)
        {
            return true;
        }

        return false;
    }

    public static IEnumerable<string> Filter(IEnumerable<string> words, StringPredicate pred)
    {
        foreach (var word in words)
        {
            if (pred(word))
            {
                yield return word;
            }
        }
    }

    public static void FilterDemo()
    {
        List<string> names = ["Adam", "Bartek", "Cyprian", "Kacper", "Zaneta", "Ala"];
        var result  = Filter(names, Prediction);
        Console.WriteLine(string.Join(",", result));
        result = Filter(names, delegate (string name) { return name.EndsWith("a"); });
        Console.WriteLine(string.Join(",", result));
    }
    
    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double Subtrack(double a, double b)
    {
        return a - b;
    }
    
    public static double Multiply(double a, double b)
    {
        return a * b;
    }

}