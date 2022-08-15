namespace TestTask.Models;

public interface IRepository<T>
{
    IEnumerable<T> Get();
}