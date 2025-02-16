using FluentValidation;
using PetFamily.Application.Volunteers.Create;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;
using System.Numerics;


namespace PetFriend.Volunteers.Application.Commands.Create;

public class CreateVolunteerCommandValidator : AbstractValidator<CreateVolunteerCommand>
{
    public CreateVolunteerCommandValidator()
    {
        RuleFor(r => r.FullNameDto)
            .MustBeValueObject(f => FullName.Create(f.FirstName, f.LastName, f.MiddleName));

        RuleFor(c => c.DescriptionDto)
            .MustBeValueObject(d => Description.Create(d.Value));

        RuleFor(c => c.PhoneNumberDto)
            .MustBeValueObject(p => PhoneNumber.Create(p.PhoneNumber));

        RuleFor(c => c.YearsOfExperience)
            .GreaterThan(0);

        RuleForEach(c => c.SocialNetworkListDto)
            .MustBeValueObject(s => SocialNetwork.Create(s.UserName, s.Description, s.Link));

        RuleForEach(c => c.RequisiteListDto)
            .MustBeValueObject(r => Requisite.Create(r.Title, r.Description));
    }
}