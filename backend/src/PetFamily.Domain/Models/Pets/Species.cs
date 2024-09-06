using CSharpFunctionalExtensions;
using PetFamily.Domain.Models.Pets.Ids;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;

public class Species : Shared.Entity<SpeciesId>
{ 
    //For EF Сore
    private Species(SpeciesId id) : base(id)
    {
    }

    private Species(SpeciesId id, string name, List<Breed> breeds) : base(id)
    {
        Name = name;
        Breeds = breeds;
    }

    public string Name { get; private set; } = default!;

    public List<Breed> Breeds { get; private set; }

    public void AddBreed(Breed breed)
    {
        Breeds.Add(breed);
    }

    public static Result<Species, Error> Create(SpeciesId id, string name, List<Breed> breeds)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Errors.General.ValueIsEmpty(nameof(Name));
        }

        if (name.Length > Constants.MAX_PET_SPECIES_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalidLength(nameof(Name));
        }

        return new Species(id, name, breeds);
    }
}
