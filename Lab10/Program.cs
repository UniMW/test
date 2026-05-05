namespace Lab10;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public static void Task1()
    {
        var task = Task.Run(() =>
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Task.Delay(2000).Wait();
            Console.WriteLine("Hello, World!");
        });
        Console.WriteLine("End");
        task.Wait();
    }

    public static void Task3()
    {
        var timeout = Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                Task.Delay(1000).Wait();
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.WriteLine($"Zostało {5-i} sekund");
            }

        });
        string input = "";
        var loop = Task.Run(() =>
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 1;
            input = Console.ReadLine();
            
        });
        Task.WaitAny(timeout, loop);
        Console.WriteLine($"Wpisałeś {input.Length} znaków");
    }
    public static void Task2()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        var task = Task.Run((() =>
        {
            var f = Fib(50, token);
            Console.WriteLine(f);
            // int a = 0;
            // int b = 1;
            // for (int i = 0; i <= 50; i++)
            // {
            //     Console.WriteLine(a);
            //     int next = a + b;
            //     a = b;
            //     b = next;
            // }
        }));
        var end = Task.Run((() =>
        {
            while (Console.ReadKey().Key != ConsoleKey.Q)
            {
                Console.WriteLine("Press Q to quit");
            }
            cts.Cancel();
            Console.WriteLine("Obliczenie zostało anulowane");
        }));
        Task.WaitAny(task, end);
    }

    public static long Fib(int n, CancellationToken token)
    {
        if (token.IsCancellationRequested)
        {
            return -1;
        }

        if (n == 0)
        {
            return 0;
        }

        if (n == 1)
        {
            return 1;
        }

        return Fib(n - 1, token) - Fib(n - 2, token);
    }

    public static void Task4()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        var task = Task.Run((() =>
        {
            var f = Fib(50, token);
            Console.WriteLine(f);
            if (!token.IsCancellationRequested)
            {
                return f;
            }

            return -1;
        }));
        task.GetAwaiter().OnCompleted(() =>
        {
            Console.WriteLine($"Obliczony wyraz {task.Result}");
            var task2 = Task.Run(() =>
            {
                Task.Delay(1000).Wait();
            });
        });
        Console.WriteLine("Last line");
    }

    public static void Task5()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        var task = Task.Run((() =>
        {
            var f = Fib(50, token);
            Console.WriteLine(f);
            if (!token.IsCancellationRequested)
            {
                return f;
            }

            return -1;
        }));
    }
}