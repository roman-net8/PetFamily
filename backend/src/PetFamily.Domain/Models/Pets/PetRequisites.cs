using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;

public record PetRequisites
{
    public PetRequisites() { }
    public PetRequisites(IEnumerable<Requisite> requisites)
    {
        Requisites = requisites.ToList();
    }

    public IReadOnlyList<Requisite> Requisites { get; } = [];
}
