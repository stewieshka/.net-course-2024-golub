using System.Collections;
using System.Diagnostics;
using BankSystem.Domain;
using Services;

namespace PracticeWithTypes;

public static class Program
{
    public static void Main()
    {
        var person = new Person
        {
            BirthDay = new DateOnly(2004, 08, 07),
            FirstName = "Stepan",
            LastName = "Golub",
            PhoneNumber = "Test"
        };

        Console.WriteLine(person.GetFullName());
        
        var employee = new Employee
        {
            BirthDay = new DateOnly(2004, 08, 07),
            FirstName = "Stepan",
            LastName = "Golub",
            PhoneNumber = "Test"
        };
        
        ChangeContract(employee);

        Console.WriteLine(employee.Contract);

        var currency = new Currency
        {
            Code = "USD",
            Name = "Dollar"
        };

        Console.WriteLine(currency.GetInfo());
        
        ChangeCurrency(ref currency, "EUR", "Euro");

        Console.WriteLine(currency.GetInfo());
        
        var client = new Client
        {
            BirthDay = new DateOnly(2004, 08, 07),
            FirstName = "Stepan",
            LastName = "Golub",
            PhoneNumber = "Test"
        };

        var emp2 = BankService.Promote(client);

        Console.WriteLine(emp2.GetType());
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
}