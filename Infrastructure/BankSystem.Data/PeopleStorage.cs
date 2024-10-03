using BankSystem.Domain;

namespace BankSystem.Data;

public class PeopleStorage<T>
    where T : Person
{
    private readonly List<T> _people = [];

    public void MyAdd(T entity)
    {
        _people.Add(entity);
    }

    public void MyAddRange(IEnumerable<T> entities)
    {
        _people.AddRange(entities);
    }

    public T? MyMinBy<TKey>(Func<T, TKey> selector)
    {
        return _people.MinBy(selector);
    }
    
    public T? MyMaxBy<TKey>(Func<T, TKey> selector)
    {
        return _people.MaxBy(selector);
    }
    
    public double MyAverage(Func<T, double> selector)
    {
        return _people.Average(selector);
    }
}