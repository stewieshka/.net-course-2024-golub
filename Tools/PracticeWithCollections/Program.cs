using System.Diagnostics;
using Services;

namespace PracticeWithCollections;

public static class Program
{
    private static readonly Stopwatch Stopwatch = new();
    
    public static void Main()
    {
        Console.WriteLine("Поиск в списке через Find");
        Measure(ListFind);

        Console.WriteLine("Поиск в списке через FirstOrDefault");
        Measure(ListFirstOrDefault);

        Console.WriteLine("Поиск в словаре по ключу");
        Measure(DictionarySearchByKey);

        Console.WriteLine("Поиск в словаре через FirstOrDefault");
        Measure(DictionaryFirstOrDefault);

        Console.WriteLine("Выбор клиентов младше 35");
        Measure(ListSelectUnder35);

        Console.WriteLine("Поиск сотрудника с минимальной зарплатой");
        Measure(MinimumSalary);
    }

    private static void Measure(Action action)
    {
        Stopwatch.Reset();
        
        Stopwatch.Start();
        
        action();
        
        Stopwatch.Stop();

        Console.WriteLine($"Потрачено {Stopwatch.ElapsedMilliseconds} мс");
    }

    private static void ListFind()
    {
        var list = TestDataGenerator.GenerateClientList();

        // Для наглядности времени поиска использую последнего клиента
        var client = list.Find(x => x.PhoneNumber == list[999].PhoneNumber);
    }

    private static void ListFirstOrDefault()
    {
        var list = TestDataGenerator.GenerateClientList();

        var client = list.FirstOrDefault(x => x.PhoneNumber == list[999].PhoneNumber);
    }

    private static void DictionarySearchByKey()
    {
        var dict = TestDataGenerator.GenerateClientDictionary();

        var client = dict.Last();

        var foundedClient = dict[client.Key];
    }

    private static void DictionaryFirstOrDefault()
    {
        var dict = TestDataGenerator.GenerateClientDictionary();

        var client = dict.Last();

        var foundedClient = dict.FirstOrDefault(x => x.Key == client.Value.PhoneNumber);
    }

    private static void ListSelectUnder35()
    {
        var list = TestDataGenerator.GenerateClientList();

        var clientUnder35 = list.Where(x => x.CalculateAge() < 35).ToList();
    }

    private static void MinimumSalary()
    {
        var list = TestDataGenerator.GenerateEmployeeList();
        
        var emp = list[0];

        for (var i = 1; i < list.Count; i++)
        {
            if (list[i].Salary < emp.Salary)
            {
                emp = list[i];
            }
        }
    }
}