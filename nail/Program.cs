using System;
using System.Collections.Generic;
using System.Linq;

public class MedianFinder
{
    private List<int> nums;

    public MedianFinder()
    {
        nums = new List<int>();
    }

    // Добавляем число в список
    public void AddNum(int num)
    {
        nums.Add(num);
        nums.Sort(); // Сортируем, чтобы найти медиану проще
    }

    // Находим медиану
    public double FindMedian()
    {
        if (nums.Count == 0)
        {
            throw new InvalidOperationException("Нельзя найти медиану, если нет чисел.");
        }

        int n = nums.Count;

        // Если нечётное количество чисел, медиана — это середина
        if (n % 2 == 1)
        {
            return nums[n / 2];
        }
        else
        {
            // Если чётное, медиана — это среднее из двух центральных
            return (nums[n / 2 - 1] + nums[n / 2]) / 2.0;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MedianFinder mf = null;
        List<object> result = new List<object>();

        Console.WriteLine("Введите команды в формате:");
        Console.WriteLine("[\"MedianFinder\", \"addNum\", \"addNum\", \"findMedian\", \"addNum\", \"findMedian\"]");
        Console.WriteLine("[[], [1], [2], [], [3], []]");
        Console.WriteLine("Введите команды (или 'exit' для завершения):");

        while (true)
        {
            string command = Console.ReadLine();
            if (command.ToLower() == "exit")
                break;

            try
            {
                // Инициализация объекта при вызове "MedianFinder"
                if (command == "MedianFinder")
                {
                    mf = new MedianFinder();
                    result.Add(null);
                }
                // Добавляем число, если команда "addNum"
                else if (command.StartsWith("addNum"))
                {
                    Console.WriteLine("Введи число:");
                    string numInput = Console.ReadLine();
                    if (int.TryParse(numInput, out int num))
                    {
                        mf.AddNum(num);
                        result.Add(null);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: надо ввести число.");
                    }
                }
                // Вычисляем медиану, если команда "findMedian"
                else if (command == "findMedian")
                {
                    if (mf != null)
                    {
                        try
                        {
                            double median = mf.FindMedian();
                            result.Add(median);
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("Ошибка: нет чисел для медианы.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: создайте объект MedianFinder.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: не понимаю такую команду.");
                }

                // Вывод результата
                Console.WriteLine("Результат:");
                Console.WriteLine("[{0}]", string.Join(", ", result.Select(r => r == null ? "null" : ((double)r).ToString("0.0"))));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при обработке: " + ex.Message);
            }

            Console.WriteLine("\nВведите новую команду (или 'exit' для завершения):");
        }
    }
}
