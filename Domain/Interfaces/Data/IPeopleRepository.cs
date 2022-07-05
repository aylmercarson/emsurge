using Domain.Models.PersonModels;

namespace Domain.Interfaces.Data;
public interface IPeopleRepository
{
    public Task<IEnumerable<Person>> GetPeopleAsync();
}
