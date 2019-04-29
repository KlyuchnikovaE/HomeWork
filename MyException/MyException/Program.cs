using System;

namespace MyException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int x = 10;
                int y = x / 2;
                Console.WriteLine($"Результат: {y}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Исключение:{ex.Message}");
                Console.WriteLine($"Метод:{ex.TargetSite}");
                Console.WriteLine($"Трассировка стека:{ex.StackTrace}");
            }
            Console.Read();

        }
    }
}
