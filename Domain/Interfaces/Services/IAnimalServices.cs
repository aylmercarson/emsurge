using Domain.Models.AnimalModels;

namespace Domain.Interfaces.Services;
public interface IAnimalServices
{
    public Animal? GetByIdOrDefault(Guid id);

    public Task<IEnumerable<Animal>> GetAllAsync();
}
