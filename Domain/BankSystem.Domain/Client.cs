using System.Text.Json;

namespace BankSystem.Domain;

public class Client : Person
{
    public override int GetHashCode()
    {
        return FirstName.GetHashCode() + LastName.GetHashCode() + PhoneNumber.GetHashCode();
    }
    
    public override bool Equals(object? obj)
    {
        return JsonSerializer.Serialize(obj).Equals(JsonSerializer.Serialize(this));
    }
}