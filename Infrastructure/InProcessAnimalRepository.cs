using Domain.Interfaces.Data;
using Domain.Models.AnimalModels;
using System.Collections.Immutable;

namespace Infrastructure;
public class InProcessAnimalRepository : IInProcessAnimalRepository
{
    public Animal? GetByIdOrDefault(Guid id) => AnimalMap.TryGetValue(id, out var result) ? result : default;

    public IEnumerable<Animal> GetAll() => AnimalMap.Values;

    private readonly static ImmutableDictionary<Guid, Animal> AnimalMap = Enumerable.Range(1, 20).Select(
        x => new Animal(
                        Guid.NewGuid(),
                        $"Animal #{x}",
                        new(Guid.NewGuid(), $"Species #{x+1}", new(Guid.NewGuid(), $"SubSpecies #{x+2}"))
                 )
        ).ToImmutableDictionary(x => x.Id);
}
