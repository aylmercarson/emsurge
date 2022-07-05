using Domain.Models.PersonModels;

namespace Domain.Interfaces.Data;
public interface IInProcessPeopleRepository
{
    public Person? GetByIdOrDefault(Guid id);

    public IEnumerable<Person> GetAll();
}
