using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using Moq;
using System.Linq;
using UIWeb.Pages;
using Xunit;

namespace DevelopmentTests.UI;
public class IndexModelTests : TestBase
{
    [Fact]
    public void ShouldRenderAllPeople()
    {
        var mockPeopleServices = new Mock<IPersonServices>();
        mockPeopleServices.Setup(p => p.GetAll()).Returns(PeopleMap.Values);

        var sut = new IndexModel(new NoOpLogger<IndexModel>(), mockPeopleServices.Object);

        sut.OnGet();

        Assert.Equal(20, sut.People.Count());
    }
}
