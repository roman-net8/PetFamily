﻿using CSharpFunctionalExtensions;
using PetFamily.Domain.Models.Pets;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Domain.Models.Volunteers;

public class Volunteer : Shared.Entity<VolunteerId>
{
    //For EF Сore
    private Volunteer(VolunteerId id) : base(id)
    {
    }

    public Volunteer(
        VolunteerId id,
        FullName fullName,
        PhoneNumber phoneNumber,
        Email email,
        Description description,
        Decimal yearsOfExperience,
        VolunteerDetails volunteerDetails)
        : base(id)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        Description = description;
        YearsOfExperience = yearsOfExperience;
        Details = volunteerDetails;
    }

    public FullName FullName { get; private set; } = default!;
    public PhoneNumber PhoneNumber { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Description Description { get; private set; } = default!;
    public Decimal YearsOfExperience { get; private set; }
    public VolunteerDetails Details { get; private set; }
    public List<Pet> Pets { get; private set; } = new();

    public int GetAmountPetsThatHaveFoundHome() => Pets.Count(p => p.HelpStatus == HelpStatus.FoundHome);
    public int GetAmountPetsThatSearchHome() => Pets.Count(p => p.HelpStatus == HelpStatus.NeedHome);
    public int GetAmountPetsOnTreatment() => Pets.Count(p => p.HelpStatus == HelpStatus.OnTreatment);

    public static Result<Volunteer, Error> Create(
        VolunteerId id,
        FullName fullName,
        PhoneNumber phoneNumber,
        Email email,
        Description description,
        Decimal yearsOfExperience,
        VolunteerDetails volunteerDetails)
    {
        if (id == null)
            Errors.General.ValueIsInvalid("Volunteer.id");

        return new Volunteer(
            id,
            fullName,
            phoneNumber,
            email,
            description,
            yearsOfExperience,
            volunteerDetails);
    }

}
