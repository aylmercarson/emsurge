using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using Domain.Models.PersonModels;

namespace Domain.Services;
public class PersonServices: IServices<Person>
{
    private readonly IRepository<Person> _iRepository;

    public PersonServices(IRepository<Person> iPeopleRepository)
    {
        _iRepository = iPeopleRepository;
    }

    //TODO: these should/could be cached
    public async Task<IEnumerable<Person>> GetAllAsync() => await _iRepository.GetAllAsync();

    //TODO: retrieve from cache
    public async Task<Person>? GetByIdOrDefault(Guid id) => await _iRepository.GetByIdOrDefault(id);
}
