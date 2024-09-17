using System.Collections;
using System.Diagnostics;
using BankSystem.Domain;
using Services;

namespace PracticeWithTypes;

public static class Program
{
    public static void Main()
    {
        var person = new Person(new DateOnly(2004, 08, 07), "Stepan", "Golub");

        Console.WriteLine(person.GetFullName());
        
        var employee = new Employee(new DateOnly(2004, 08, 07), "Stepan", "Golub");
        
        ChangeContract(employee);

        Console.WriteLine(employee.Contract);

        var currency = new Currency("USD", "US Dollar");

        Console.WriteLine(currency.GetInfo());
        
        ChangeCurrency(ref currency, "EUR", "Euro");

        Console.WriteLine(currency.GetInfo());
        
        var client = new Client(new DateOnly(2004, 08, 07), "Stepan", "Golub");

        var emp2 = BankService.Promote(client);

        Console.WriteLine(emp2.GetType());

        TestBoxUnbox();
    }

    // Employee - ссылочный тип, в метод передаётся ссылка. При изменении внутри меняется и там, откуда передали.
    private static void ChangeContract(Employee employee)
    {
        employee.Contract = $"{employee.GetFullName()} был принят на работу | {DateTime.Now}";
    }

    // Метод, принимающий Currency через ref, что позволяет передать значимый тип по ссылке.
    private static void ChangeCurrency(ref Currency currency, string code, string name)
    {
        currency.Code = code;
        currency.Name = name;
    }

    private static void TestBoxUnbox()
    {
        var sw = new Stopwatch();

        var arr = new ArrayList();
        
        sw.Start();

        for (var i = 0; i < 100_000; i++)
        {
            arr.Add(i);
        }
        
        sw.Stop();
        Console.WriteLine($"На упаковку ушло: {sw.ElapsedTicks} тиков");
        sw.Reset();
        
        sw.Start();

        for (var i = 0; i < 100_000; i++)
        {
            var num = (int)arr[i]!;
            var num2 = num * 10;
        }
        
        sw.Stop();

        Console.WriteLine($"На распаковку ушло: {sw.ElapsedTicks} тиков");
    }
}