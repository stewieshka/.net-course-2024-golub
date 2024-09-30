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
    
    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, PhoneNumber);
    }
    
    public override bool Equals(object? obj)
    {
        return Equals(obj as Person);
    }

    public bool Equals(Person? person)
    {
        return person is not null 
               && person.FirstName == FirstName 
               && person.LastName == LastName 
               && person.PhoneNumber == PhoneNumber;
    }

    public static bool operator ==(Person? left, Person? right)
    {
        if (ReferenceEquals(left, right))
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(Person left, Person right)
    {
        return !(left == right);
    }
}