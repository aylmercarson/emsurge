using Domain.Models.AnimalModels;

namespace Domain.Interfaces.Data;
public interface IInProcessAnimalRepository
{
    public Animal? GetByIdOrDefault(Guid id);

    public IEnumerable<Animal> GetAll();
}
