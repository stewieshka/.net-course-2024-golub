namespace BankSystem.Domain;

public class Person
{
    public DateOnly BirthDay { get; set; }
    
    public string PhoneNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? MiddleName { get; set; }

    public string GetFullName()
        => $"{LastName} {FirstName} {MiddleName}";

    public int CalculateAge()
        => DateTime.Now.Year - BirthDay.Year;
}