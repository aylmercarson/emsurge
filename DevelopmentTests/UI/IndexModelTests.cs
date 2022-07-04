using Domain.Interfaces;
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
        var mockPeopleRepository = new Mock<IInProcessPeopleRepository>();
        mockPeopleRepository.Setup(p => p.GetAll()).Returns(PeopleMap.Values);

        var sut = new IndexModel(new NoOpLogger<IndexModel>(), mockPeopleRepository.Object);

        sut.OnGet();

        Assert.Equal(20, sut.People.Count());
    }
}
