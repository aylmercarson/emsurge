using System.Linq;
using UIWeb.Pages;
using Xunit;

namespace DevelopmentTests.UI;
public class IndexModelTests
{
    [Fact]
    public void ShouldRenderAllPeople()
    {
        var sut = new IndexModel(new NoOpLogger<IndexModel>());

        sut.OnGet();

        Assert.Equal(20, sut.People.Count());
    }
}
