using PetFamily.Domain.Models.Pets;

namespace PetFamily.Domain.Shared.ValueObjects;

public record Photos
{
    private Photos()
    { 
    }
 
    public Photos(IEnumerable<PetPhoto> value)
    {
        Value = value.ToList();
    }

    public IReadOnlyList<PetPhoto> Value { get; } = new List<PetPhoto>();
};
