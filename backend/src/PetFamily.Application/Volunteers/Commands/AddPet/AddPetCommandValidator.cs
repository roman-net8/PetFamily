

using FluentValidation;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.Commands.AddPet;

public class AddPetCommandValidator : AbstractValidator<AddPetCommand>
{
    public AddPetCommandValidator()
    {
        RuleFor(r => r.Name).MinimumLength(2).WithMessage("more then 2");

        RuleFor(r => r.Description).MustBeValueObject(Description.Create);

        RuleFor(r => r.OwnersPhoneNumber).MustBeValueObject(PhoneNumber.Create);

        RuleFor(c => c.Address).MustBeValueObject(
            a => Address.Create(a.Country, a.City, a.Street, a.HouseNumber, a.AppartmentNumber)); 
    }
}