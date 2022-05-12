using Infrastructure;
using System.Linq;
using UIWeb.Pages;
using Xunit;

namespace DevelopmentTests.UI;
public class PersonModelTests
{
    [Fact]
    public void ShouldRenderPersonDetails()
    {
        var people = new InProcessPeopleRepository();
        var person = people.GetAll().First();
        var sut = new PersonModel(new NoOpLogger<PersonModel>());
        sut.OnGet(person.Id);

        Assert.Equal(person.Id, sut.Person.Id);
    }
}
