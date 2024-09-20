namespace BankSystem.Domain;

/// <summary>
/// Модель, описывающая сущность человека
/// </summary>
/// <param name="birthDay"></param>
/// <param name="firstName"></param>
/// <param name="lastName"></param>
/// <param name="middleName"></param>
public class Person
{
    // Для Bogus
    public Person() {}
    
    public Person(DateOnly birthDay, string phoneNumber, string firstName, string lastName, string? middleName = null)
    {
        BirthDay = birthDay;
        PhoneNumber = phoneNumber;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }
    
    /// <summary>
    /// Дата рождения. Не DateTime, т.к. DateTime дополнительно хранит ненужное нам время.
    /// </summary>
    public DateOnly BirthDay { get; set; }
    
    public string PhoneNumber { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Отчество. Nullable, т.к. не у всех есть.
    /// </summary>
    public string? MiddleName { get; set; }

    public string GetFullName()
        => $"{LastName} {FirstName} {MiddleName}";

    public int CalculateAge()
        => DateTime.Now.Year - BirthDay.Year;
}