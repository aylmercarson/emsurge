using Domain.Models.PersonModels;

namespace Domain.Interfaces.Services;
public interface IPersonServices
{
    public Person? GetByIdOrDefault(Guid id);

    public Task<IEnumerable<Person>> GetAllAsync();
}
