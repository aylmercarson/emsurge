namespace Domain.Models.AnimalModels;

public sealed record Animal(Guid Id, string Name, Species Species) : ModelBase(Id, Name);

