namespace Domain.Interfaces.Services;
public interface IPersonServices
{
    public Person? GetByIdOrDefault(Guid id);

    public IEnumerable<Person> GetAll();
}
