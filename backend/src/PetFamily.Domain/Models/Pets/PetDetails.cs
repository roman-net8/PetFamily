using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;

public record PetDetails
{
    public IReadOnlyList<Requisite> PetRequisites { get; } = new List<Requisite>();
}