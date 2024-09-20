namespace BankSystem.Domain;

/// <summary>
/// Модель, описывающая сущность работника
/// </summary>
public class Employee : Person
{
    // Для Bogus
    public Employee() {}
    
    public Employee(DateOnly birthDay, string phoneNumber, string firstName, string lastName, string? middleName = null)
        : base(birthDay, phoneNumber, firstName, lastName, middleName) {}
    
    public string? Contract { get; set; }
    
    public decimal Salary { get; set; }
}