namespace Domain.Models.PersonModels;

public sealed record Person(Guid Id, string Name, DateOnly DateOfBirth, Address Address) : ModelBase(Id, Name)
{
    public Person Move(Address newAddress) => this with { Address = newAddress };
}
