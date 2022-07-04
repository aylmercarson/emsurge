using Domain.Interfaces.Data;
using Domain.Interfaces.Services;

namespace Domain.Services;
public class PersonServices: IPersonServices
{
    private readonly IInProcessPeopleRepository _iInProcessPeopleRepository;

    public PersonServices(IInProcessPeopleRepository iInProcessPeopleRepository)
    {
        _iInProcessPeopleRepository = iInProcessPeopleRepository;
    }

    public Person? GetByIdOrDefault(Guid id) => _iInProcessPeopleRepository.GetByIdOrDefault(id);

    public IEnumerable<Person> GetAll() => _iInProcessPeopleRepository.GetAll();
}
