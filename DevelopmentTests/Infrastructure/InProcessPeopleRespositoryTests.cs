using Infrastructure;
using System.Linq;
using Xunit;

namespace DevelopmentTests.Infrastructure;

public class InProcessPeopleRespositoryTests
{
    [Fact]
    public void ShouldNotBeEmpty()
    {
        var sut = new InProcessPeopleRepository();

        var result = sut.GetAll();

        Assert.NotEmpty(result);
    }

    [Fact]
    public void ShouldRetrieveById()
    {
        var sut = new InProcessPeopleRepository();

        var existing = sut.GetAll().First();

        var result = sut.GetByIdOrDefault(existing.Id);

        Assert.NotNull(existing);
        Assert.NotNull(result);
    }
}
