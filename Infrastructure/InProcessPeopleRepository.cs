using Domain.Interfaces.Data;
using Domain.Models;
using System.Collections.Immutable;

namespace Infrastructure;

public class InProcessPeopleRepository : IInProcessPeopleRepository
{
    public Person? GetByIdOrDefault(Guid id) => PeopleMap.TryGetValue(id, out var result) ? result : default;

    public IEnumerable<Person> GetAll() => PeopleMap.Values;

    private readonly static ImmutableDictionary<Guid, Person> PeopleMap = Enumerable.Range(1, 20).Select(
        x => new Person(
                        Guid.NewGuid(),
                        $"Person #{x}",
                        new(1980 + x, 1 + (x % 12), 1 + (x % 20)),
                        new($"First Line #{x}", new($"Second Line #{x}"), new($"PostCode #{x}"))
                 )
        ).ToImmutableDictionary(x => x.Id);
}
