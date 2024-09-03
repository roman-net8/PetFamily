using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Domain.Models.Pets;

public class Pet : Shared.Entity<PetId>
{
    //For EF Сore
    private Pet(PetId id) : base(id)
    {
    }

    private Pet(
        PetId petId,
        NickName nickName,
        Description description,
        Color color,
        HealthInfo healthInfo,
        Address address,
        PetAttributes petAttributes, 
        bool isCastrated,
        bool isVaccinated,
        DateOnly dateOfBirth,
        DateTime createdDate,
        HelpStatus helpStatus,
        PetRequisites petRequisites,
        Photos photos,
        SpeciesBreedType speciesBreedType)
    : base(petId)
    {
        NickName = nickName;
        Description = description;
        Color = color;
        HealthInfo = healthInfo;
        PetRequisites = petRequisites;
        Address = address;
        PetAttributes = petAttributes; 
        IsCastrated = isCastrated;
        IsVaccinated = isVaccinated;
        DateOfBirth = dateOfBirth;
        CreatedDate = createdDate;
        HelpStatus = helpStatus;
        PetRequisites = petRequisites;
        Photos = photos;
        SpeciesBreed = speciesBreedType;
    }

    public NickName NickName { get; private set; } = default!;
    public Description Description { get; private set; } = default!;
    public Color Color { get; private set; } = default!;
    public HealthInfo HealthInfo { get; private set; } = default!;
    public Address Address { get; private set; } = default!;
    public PetAttributes PetAttributes { get; private set; } 
    public bool IsCastrated { get; private set; }
    public bool IsVaccinated { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public HelpStatus HelpStatus { get; private set; }
    public PetRequisites PetRequisites { get; private set; }
    public Photos Photos { get; private set; } = default!; 
    public SpeciesBreedType SpeciesBreed { get; private set; }

}