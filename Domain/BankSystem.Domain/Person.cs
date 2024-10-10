namespace BankSystem.Domain;

public class Person
{
    public DateOnly BirthDay { get; set; }
    
    public string PhoneNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PassportId { get; set; }
    public string? MiddleName { get; set; }
    

    public string GetFullName()
        => $"{LastName} {FirstName} {MiddleName}";

    public int CalculateAge()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var age = today.Year - BirthDay.Year;

        if (today < BirthDay.AddYears(age))
        {
            age--;
        }

        return age;
    }
    
    public override int GetHashCode()
    {
        return PassportId.GetHashCode();
    }
    
    public override bool Equals(object? obj)
    {
        return Equals(obj as Person);
    }

    public bool Equals(Person? person)
    {
        return person is not null
               && person.PassportId == PassportId;
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