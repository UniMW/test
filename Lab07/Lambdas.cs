using System.Globalization;

namespace Lab07;

public class Lambdas
{
    public static void Demo()
    {
        Predicate<string> isLongerThan5 = s => s.Length > 5;
        Predicate<int> a = s => s % 2 == 0;
        Func<double, double> b = s => s * s;
        Action<int, int> sum = (k,l) => Console.WriteLine(k + l);
        Console.WriteLine(a(4));
        Console.WriteLine(b(4));
        sum(2, 4);
    }
}