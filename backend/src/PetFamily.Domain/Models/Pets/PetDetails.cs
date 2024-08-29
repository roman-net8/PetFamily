using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;

public record PetDetails
{
    private readonly List<Requisite> _petRequisites = [];

    public IReadOnlyList<Requisite> PetRequisites => _petRequisites;
}