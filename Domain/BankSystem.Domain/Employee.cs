namespace BankSystem.Domain;

/// <summary>
/// Модель, описывающая сущность работника
/// </summary>
public class Employee : Person
{
    public Employee(DateOnly birthDay, string firstName, string lastName, string? middleName = null)
        : base(birthDay, firstName, lastName, middleName) {}
    
    public string? Contract { get; set; }
}