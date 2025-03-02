﻿using FluentValidation;
using PetFamily.Application.Validation;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.UpdateMainInfo;

public class UpdateMainInfoRequestValidator : AbstractValidator<UpdateMainInfoRequest>
{
/*    public UpdateMainInfoRequestValidator()
    {
        RuleFor(r => r.VolunteerId)
            .NotEmpty()
            .WithError(Errors.General.ValueIsInvalid());

        RuleFor(r => r.Dto.FullName)
            .MustBeValueObject(n => FullName.Create(n.FirstName, n.MiddleName, n.LastName));

        RuleFor(r => r.Dto.PhoneNumber).MustBeValueObject(PhoneNumber.Create);

        RuleFor(r => r.Dto.Experience).MustBeValueObject(YearsExperience.Create);

        RuleFor(r => r.Dto.Description).MustBeValueObject(Description.Create);
    }*/
}
