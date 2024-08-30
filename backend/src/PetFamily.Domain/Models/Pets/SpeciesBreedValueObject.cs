using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;
/*
public record PetProperty
{
    public Species Species { get; }

    public IReadOnlyList<Breed> Breeds { get; } = new List<Breed>();
}*/
public record SpeciesBreedValueObject
{
    public SpeciesBreedValueObject(SpeciesId speciesId, BreedId breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }

    public SpeciesId SpeciesId { get; } = default!;
    public BreedId BreedId { get; } = default!;
}