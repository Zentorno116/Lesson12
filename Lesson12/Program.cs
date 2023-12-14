using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

class Program
{
    static void Main()
    {
        Thread thread1 = new Thread(new ThreadStart(PrintNumbers));
        Thread thread2 = new Thread(new ThreadStart(PrintNumbers));
        Thread thread3 = new Thread(new ThreadStart(PrintNumbers));
        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.Write("Введите число: ");
        int num = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Квадрат числа: {num * num}");

        Task.Run(() => CalculateFactorial(num)).Wait();

        Refl refl = new Refl();
        Console.WriteLine(refl.Output());
        Console.WriteLine(refl.AddInts(1, 2));

        MethodInfo[] methods = typeof(Refl).GetMethods();
        foreach (MethodInfo method in methods)
        {
            Console.WriteLine(method.Name);
        }
    }

    static void PrintNumbers()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(i);
        }
    }

    static async Task CalculateFactorial(int num)
    {
        BigInteger factorial = 1;

        for (int i = 2; i <= num; i++)
        {
            factorial *= i;
            await Task.Delay(TimeSpan.FromSeconds(8));
        }

        Console.WriteLine($"Факториал числа: {factorial}");
    }
}

public class Refl
{
    public string Output()
    {
        return "Test-Output";
    }

    public int AddInts(int i1, int i2)
    {
        return i1 + i2;
    }
}