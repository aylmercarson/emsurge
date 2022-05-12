namespace Domain;

public record Person(Guid Id, string Name, DateOnly DateOfBirth, Address Address)
{
    public Person Move(Address newAddress) => this with { Address = newAddress };
}
