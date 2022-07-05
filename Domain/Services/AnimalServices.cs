using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using Domain.Models.AnimalModels;

namespace Domain.Services;
public class AnimalServices : IAnimalServices
{
    //private readonly IInProcessAnimalRepository _iInProcessAnimalRepository;
    private readonly IRepository<Animal> _iRepository;

    public AnimalServices(IRepository<Animal> iRepository)
    {
        _iRepository = iRepository;
    }

    public async Task<IEnumerable<Animal>> GetAllAsync() => await _iRepository.GetAllAsync();

    public Animal? GetByIdOrDefault(Guid id) => throw new NotImplementedException();
}
