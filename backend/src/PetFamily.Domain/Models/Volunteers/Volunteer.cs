using PetFamily.Domain.Models.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Volunteers;

public class Volunteer : Shared.Entity<VolunteerId>
{
    //For EF Сore
    private Volunteer(VolunteerId id) : base(id)
    {
    }

    public PersonFullName FullName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public Decimal YearsOfExperience { get; private set; }

    public int GetAmountPetsThatHaveFoundHome() => OwnedPets.Count(p => p.HelpStatus == HelpStatus.FoundHome);
    public int GetAmountPetsThatSearchHome() => OwnedPets.Count(p => p.HelpStatus == HelpStatus.NeedHome);
    public int GetAmountPetsOnTreatment() => OwnedPets.Count(p => p.HelpStatus == HelpStatus.OnTreatment);
    public string Phone { get; private set; } = default!;

    public VolunteerDetails Details { get; private set; }
    public List<Pet> OwnedPets { get; private set; } = new();
}
