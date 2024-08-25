using PetFamily.Domain.Models.Volunteers;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;

public class Pet : Shared.Entity<PetId>
{
    private readonly List<Requisite> _requisites = [];
    private readonly List<PetPhoto> _petPhoto = [];

    //For EF Сore
    private Pet(PetId id) : base(id)
    {
    }

    public string Name { get; private set; } = default!;
    public string Type { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string Breed { get; private set; } = default!;
    public string Color { get; private set; } = default!;
    public string Health { get; private set; } = default!;
    public string Address { get; private set; } = default!;
    public double Weight { get; private set; }
    public double Height { get; private set; }
    public string OwnerPhone { get; private set; } = default!;
    public bool IsCastrated { get; private set; }
    public bool IsVaccinated { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public HelpStatus HelpStatus { get; private set; }
    public IReadOnlyList<Requisite> Requisites => _requisites;
    public void AddRequisite(Requisite requisite) => _requisites.Add(requisite);
    public IReadOnlyList<PetPhoto> Photos => _petPhoto;
    public void AddRequisite(PetPhoto petPhoto) => _petPhoto.Add(petPhoto);
    public Volunteer Volunteer { get; private set; } = default!;
}
