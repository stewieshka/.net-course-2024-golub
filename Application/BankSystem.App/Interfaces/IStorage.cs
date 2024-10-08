namespace BankSystem.App.Interfaces;

public interface IStorage<T>
{
    List<T> Get(int pageSize, int pageNumber, List<Func<T, bool>> filters);
    void Add(T item);
    void Update(T item);
    void Delete(T item);
}