namespace Domain.Interfaces.Data;

public interface IRepository<T>
{
    public Task<IEnumerable<T>> GetAllAsync();

    public Task<T>? GetByIdOrDefault(Guid id);
}
