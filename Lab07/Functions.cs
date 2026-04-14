namespace Lab07;

public class Functions
{
    public static void FuncDemo()
    {
        Func<double, double, double> func = Add;
        Func<double, double> square = Square;
        Func<IEnumerable<string>, int> count = Count;
        Func<int> abc = ABC;
    }

    public static int ABC()
    {
        return 0;
    }

    public static double Add(double a, double b)
    {
        return a + b;
    }
    public static double Square(double a)
    {
        return a * a;
    }

    public static int Count(IEnumerable<string> strings)
    {
        return  strings.Count();
    }

}