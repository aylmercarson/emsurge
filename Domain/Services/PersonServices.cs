using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using Domain.Models.PersonModels;

namespace Domain.Services;
public class PersonServices: IPersonServices
{
    ///private readonly IInProcessPeopleRepository _iInProcessPeopleRepository;
    private readonly IRepository<Person> _iPeopleRepository;

    public PersonServices(
        //IInProcessPeopleRepository iInProcessPeopleRepository,
        IRepository<Person> iPeopleRepository)
    {
       // _iInProcessPeopleRepository = iInProcessPeopleRepository;
        _iPeopleRepository = iPeopleRepository;
    }

    //public Person? GetByIdOrDefault(Guid id) => _iInProcessPeopleRepository.GetByIdOrDefault(id);

    public async Task<IEnumerable<Person>> GetAllAsync() => await _iPeopleRepository.GetAllAsync();

    Person? IPersonServices.GetByIdOrDefault(Guid id) => throw new NotImplementedException();
}
