using Domain.Interfaces.Services;
using Infrastructure;
using Moq;
using System.Linq;
using UIWeb.Pages;
using Xunit;

namespace DevelopmentTests.UI;
public class PersonModelTests : TestBase
{
    [Fact]
    public void ShouldRenderPersonDetails()
    {
        var mockPeopleServices = new Mock<IPersonServices>();
        mockPeopleServices.Setup(p => p.GetAll()).Returns(PeopleMap.Values);

        var people = new InProcessPeopleRepository();
        var person = mockPeopleServices.Object.GetAll().First();
        var sut = new PersonModel(new NoOpLogger<PersonModel>(), mockPeopleServices.Object);
        sut.OnGet(person.Id);

        Assert.Equal(person.Id, sut.Person.Id);
    }
}
