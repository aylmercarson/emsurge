using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using Domain.Models.PersonModels;

namespace Domain.Services;
public class PersonServices: IServices<Person>
{
    ///private readonly IInProcessPeopleRepository _iInProcessPeopleRepository;
    private readonly IRepository<Person> _iRepository;

    public PersonServices(
        //IInProcessPeopleRepository iInProcessPeopleRepository,
        IRepository<Person> iPeopleRepository)
    {
       // _iInProcessPeopleRepository = iInProcessPeopleRepository;
        _iRepository = iPeopleRepository;
    }

    //public Person? GetByIdOrDefault(Guid id) => _iInProcessPeopleRepository.GetByIdOrDefault(id);

    public async Task<IEnumerable<Person>> GetAllAsync() => await _iRepository.GetAllAsync();

    public async Task<Person>? GetByIdOrDefault(Guid id) => await _iRepository.GetByIdOrDefault(id);
}
