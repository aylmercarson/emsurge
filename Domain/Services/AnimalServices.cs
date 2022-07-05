using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using Domain.Models.AnimalModels;

namespace Domain.Services;
public class AnimalServices : IAnimalServices
{
    private readonly IInProcessAnimalRepository _iInProcessAnimalRepository;

    public AnimalServices(IInProcessAnimalRepository iInProcessAnimalRepository)
    {
        _iInProcessAnimalRepository = iInProcessAnimalRepository;
    }

    public Animal? GetByIdOrDefault(Guid id) => _iInProcessAnimalRepository.GetByIdOrDefault(id);

    public IEnumerable<Animal> GetAll() => _iInProcessAnimalRepository.GetAll();
}
