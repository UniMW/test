namespace Lab07;

public class Predicates
{
    public static void PredicatesDemo()
    {
        Predicate<string> isvalid = IsValid;
        Func<IEnumerable<int>, int, bool> test = Test;
        Console.WriteLine(isvalid("helllllllloa"));
    }

    public static bool IsValid(string s)
    {
        return s.Length > 5 && s.EndsWith("a");
    }
    public static bool Test(IEnumerable<int> values, int count )
    {
        return values.Count() == count;
    }
    
}