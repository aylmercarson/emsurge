namespace Domain.Interfaces.Services;
public interface IServices<T>
{
    public Task<T>? GetByIdOrDefault(Guid id);

    public Task<IEnumerable<T>> GetAllAsync();
}
