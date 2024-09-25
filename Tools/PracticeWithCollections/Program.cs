using System.Diagnostics;
using BankSystem.App.Services;
using BankSystem.Domain;

namespace PracticeWithCollections;

public static class Program
{
    private static readonly List<Client> ClientsList = TestDataGenerator.GenerateClientsList(1000);
    private static readonly List<Employee> EmployeesList = TestDataGenerator.GenerateEmployeesList(1000);
    private static readonly Dictionary<string, Client> ClientsDict = TestDataGenerator.GenerateClientsDictionary(1000);

    private static readonly Client LastClientInList = ClientsList.LastOrDefault()!;
    private static readonly KeyValuePair<string, Client> LastClientInDict = ClientsDict.LastOrDefault()!;

    private static readonly Stopwatch Stopwatch = new();

    public static void Main()
    {
        Measure(ListFind, "Поиск в списке", 1000);
        Measure(ClientsWhereAgeBelow, "Выбор элементов из списка с возрастом меньше 35", 1000);
        Measure(EmployeesMinimumSalary, "Поиск сотрудника с минимальной зарплатой", 1000);
        Measure(DictionarySearchByKey, "Поиск в словаре по ключу", 1000);
        Measure(ClientsDictLastOrDefault, "Поиск последнего в словаре через LastOrDefault", 1000);
    }

    private static void Measure(Action action, string text, int amount)
    {
        Console.WriteLine(text);

        var times = new long[amount];

        for (var i = 0; i < amount; i++)
        {
            times[i] = MeasureOneTime(action);
        }

        var mean = times.Sum() / amount;

        Console.WriteLine($"Потрачено в среднем: {mean} тиков");
    }

    private static long MeasureOneTime(Action action)
    {
        Stopwatch.Reset();

        Stopwatch.Start();

        action();

        Stopwatch.Stop();

        return Stopwatch.ElapsedTicks;
    }

    private static void ListFind()
    {
        var foundedClient = ClientsList.Find(x => x.PhoneNumber == LastClientInList.PhoneNumber);
    }

    private static void DictionarySearchByKey()
    {
        var foundedClient = ClientsDict[LastClientInDict.Key];
    }

    private static void ClientsWhereAgeBelow()
    {
        var foundedClients = ClientsList.Where(x => x.CalculateAge() < 35).ToList();
    }

    private static void EmployeesMinimumSalary()
    {
        var employeeWithMinSalary = EmployeesList.MinBy(x => x.Salary);
    }

    private static void ClientsDictLastOrDefault()
    {
        var last = ClientsDict.LastOrDefault();
    }
}