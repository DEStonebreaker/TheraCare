namespace Library.TheraCare.Services.Proxies;

public interface IBaseProxy<T>
{
    Task<T> GetById(Guid id);
    Task Create(T item);
    Task Update(T item);
    Task Delete(Guid id);
    Task<IEnumerable<T>> GetAll();
    IObservable<T> GetObservable();
}