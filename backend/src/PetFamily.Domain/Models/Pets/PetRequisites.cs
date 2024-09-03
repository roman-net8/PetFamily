using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Domain.Models.Pets;

public record PetRequisites
{
    public IReadOnlyList<Requisite> PetRequisiteList { get; } = new List<Requisite>();
}