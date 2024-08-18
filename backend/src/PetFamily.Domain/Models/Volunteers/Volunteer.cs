using PetFamily.Domain.Models.CommonModels;
using PetFamily.Domain.Models.Pets;

namespace PetFamily.Domain.Models.Volunteers
{
    public class Volunteer
    {
        private readonly List<Requisite> _requisites = [];
        private readonly List<SocialNetwork> _socialMediaProfile = [];
        private readonly List<Pet> _ownedPets = [];

        public string FullName { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string GeneralDescription { get; private set; } = default!;
        public Decimal YearsOfExperience { get; private set; }
        public int GetAmountPetsThatHaveFoundHome() => _ownedPets.Count(p => p.HelpStatus == HelpStatus.FoundHome);
        public int GetAmountPetsThatSearchHome() => _ownedPets.Count(p => p.HelpStatus == HelpStatus.NeeedHome);
        public int GetAmountPetsOnTreatment() => _ownedPets.Count(p => p.HelpStatus == HelpStatus.OnTreatment);
        public string Phone { get; private set; } = default!;
        public IReadOnlyList<SocialNetwork> SocialMediaProfile => _socialMediaProfile;
        public void AddSocialNetwork(SocialNetwork socialNetwork) => _socialMediaProfile.Add(socialNetwork);
        public IReadOnlyList<Requisite> Requisites => _requisites;
        public void AddRequisite(Requisite requisite) => _requisites.Add(requisite);
        public IReadOnlyList<Pet> OwnedPets => _ownedPets;
        public void AddOwnedPet(Pet pet) => _ownedPets.Add(pet);
    }
}
