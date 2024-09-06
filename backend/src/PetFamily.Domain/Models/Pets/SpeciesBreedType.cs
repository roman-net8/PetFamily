using PetFamily.Domain.Models.Pets.Ids;

namespace PetFamily.Domain.Models.Pets;

public record SpeciesBreedType
{
    public SpeciesBreedType(SpeciesId speciesId, BreedId breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }

    public SpeciesId SpeciesId { get; private set; } = default!;
    public BreedId BreedId { get; private set; } = default!;
}