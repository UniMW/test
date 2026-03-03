namespace Lab02;

class Program
{
    static void Main(string[] args)
    {
        MoneyDemoAdd();
    }

    public static void MoneyDemoAdd()
    {
        Money a = new Money()
        {
            Currency = Currency.USD,
            Value = 100
        };
        Money b = new Money()
        {
            Currency = Currency.USD,
            Value = 499
        };
        Console.WriteLine(a + b);
        Console.WriteLine(a == b);
        Console.WriteLine(a != b);
    }

    public static void Task01()
    {  
        decimal eurSum = 0.0m;
        decimal usdSum = 0.0m;
        List<Money> list = new List<Money>();
        for (int i = 0; i < 10000; i++)
        {
            list.Add(new Money()
            {
                Value = Random.Shared.Next(0, 10_000),
                Currency = Random.Shared.Next(2) == 1 ? Currency.USD : Currency.EUR,
            });
            if (list[i].Currency == Currency.USD)
            {
                usdSum += list[i];
            }
            else
            {
                eurSum += list[i];
            }

        }

        decimal eurTax = eurSum * 0.23m;
        decimal usdTax = usdSum * 0.23m;
        Console.WriteLine(eurTax);
        Console.WriteLine(usdTax);

        
    }

    public static void StringExtensionDemo()
    {
        Console.WriteLine("Hello World!\n".Repeat(5));
    }
    public static void StarEncodeDemo()
    {
        Console.WriteLine("Hello world!".StarEncode('*'));
    }
}