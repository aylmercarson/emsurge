using Domain;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Immutable;
using System.Linq;
using UIWeb.Pages;
using Xunit;

namespace DevelopmentTests.UI;
public class IndexModelTests
{
    [Fact]
    public void ShouldRenderAllPeople()
    {
        var mockPeopleRepository = new Mock<IInProcessPeopleRepository>();
        mockPeopleRepository.Setup(p => p.GetAll()).Returns(PeopleMap.Values);

        var sut = new IndexModel(new NoOpLogger<IndexModel>(), mockPeopleRepository.Object);

        sut.OnGet();

        Assert.Equal(20, sut.People.Count());
    }

    //TODO: extract to setup 
    private readonly static ImmutableDictionary<Guid, Person> PeopleMap = Enumerable.Range(1, 20).Select(
    x => new Person(
                    Guid.NewGuid(),
                    $"Person #{x}",
                    new(1980 + x, 1 + (x % 12), 1 + (x % 20)),
                    new($"First Line #{x}", new($"Second Line #{x}"), new($"PostCode #{x}"))
             )
    ).ToImmutableDictionary(x => x.Id);
}
