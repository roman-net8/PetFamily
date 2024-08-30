namespace PetFamily.Domain.Models.Pets;

public record SpeciesBreedValueObject
{
    public SpeciesBreedValueObject(SpeciesId speciesId, BreedId breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }

    public SpeciesId SpeciesId { get; private set; } = default!;
    public BreedId BreedId { get; private set; } = default!;
}