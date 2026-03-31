namespace lab06;

class Program
{
    static void Main(string[] args)
    {
        IEnumerableDemo([1,4,5]);
        IEnumerableDemo(Evens(100));
        /*IEnumerableDemo(GetNames());*/
        /*IEnumerableDemo(Greeting([
            "Igor", "Mateusz", "Patryk"
        ]));*/
    }

    public static void HeroDemo()
    {
        Hero hero = new Hero()
        {
            Body = "Zbroja",
            Head = "Kaszkiet",
            LeftHand = "Tarcza",
            RightHand = "Mieczyk",
            Items = ["Proca", "1 diament"]
        };
        foreach (var item in hero)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(hero["Body"]);
    }

    public static IEnumerable<string> Greeting(string[] names)
    {
        foreach (var name in names)
        {
            if (name.EndsWith("a"))
            {
                yield return "Pani " + name;
            }
            else
            {
                yield return "Pan " + name;
            }
            
        }
    }
    public static IEnumerable<int> Evens(int limit)
    {
        for (int i = 0; i < limit + 1; i++)
        {
            if (i % 2 == 0)
            {
                yield return i;
            }
        }
    }

    public static IEnumerable<string> GetNames()
    {
        yield return "Jacek";
        yield return "Basia";
        yield return "Kasia";
    }
    public static void IEnumerableDemo(IEnumerable<int> numbers)
    {
        var iterator = numbers.GetEnumerator();
        while (iterator.MoveNext())
        {
            Console.WriteLine(iterator.Current);
        }

        for (var i = numbers.GetEnumerator(); i.MoveNext();)
        {
            Console.WriteLine(i.Current);
        }
        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}