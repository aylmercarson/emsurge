using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using Domain.Models.PersonModels;

namespace Domain.Services;
public class PersonServices: IPersonServices
{
    private readonly IInProcessPeopleRepository _iInProcessPeopleRepository;
    private readonly IPeopleRepository _iPeopleRepository;

    public PersonServices(IInProcessPeopleRepository iInProcessPeopleRepository, IPeopleRepository iPeopleRepository)
    {
        _iInProcessPeopleRepository = iInProcessPeopleRepository;
        _iPeopleRepository = iPeopleRepository;
    }

    public Person? GetByIdOrDefault(Guid id) => _iInProcessPeopleRepository.GetByIdOrDefault(id);

    public async Task<IEnumerable<Person>> GetAll() => await _iPeopleRepository.GetPeopleAsync();
}
