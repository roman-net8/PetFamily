using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;

public class Breed : Shared.Entity<BreedId>
{
    //For EF Сore
    private Breed(BreedId id) : base(id)
    {
    }

    private Breed(BreedId id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; private set; } = string.Empty;

    public static Result<Breed, Error> Create(BreedId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Errors.General.ValueIsEmpty(nameof(Name));
        }

        if (name.Length > Constants.MAX_BREED_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalidLength(nameof(Name));
        }

        return new Breed(id, name);
    }
}
