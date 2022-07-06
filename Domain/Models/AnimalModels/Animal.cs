using Domain.Enums;
using Domain.Models.PersonModels;

namespace Domain.Models.AnimalModels;

public sealed record Animal(Guid Id, string Name, Species Species, AnimalClassificationEnum Classification, Person? Owner) : ModelBase(Id, Name);

