using Domain.Models.PersonModels;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace DevelopmentTests;
public class TestBase
{
    //TODO: extract to setup 
    public readonly static ImmutableDictionary<Guid, Person> PeopleMap = Enumerable.Range(1, 20).Select(
    x => new Person(
                    Guid.NewGuid(),
                    $"Person #{x}",
                    new(1980 + x, 1 + (x % 12), 1 + (x % 20)),
                    new($"First Line #{x}", new($"Second Line #{x}"), new($"PostCode #{x}"))
             )
    ).ToImmutableDictionary(x => x.Id);
}
