using Domain;
using System;
using Xunit;

namespace DevelopmentTests;

public class PersonTests
{
    [Fact]
    public void ShouldChangeAddressWhenMoving()
    {
        var oldAddress = new Address("Old first line", "Old second line", new("Old PostCode"));
        var sut = new Person(Guid.NewGuid(), "Test Name", new(2000, 1, 1), oldAddress);
        var newAddress = new Address("New first line", "New second line", new("New PostCode"));

        var result = sut.Move(newAddress);

        Assert.Equal(sut.Address, oldAddress);
        Assert.NotEqual(sut.Address, newAddress);
        Assert.Equal(result.Address, newAddress);
    }
}
