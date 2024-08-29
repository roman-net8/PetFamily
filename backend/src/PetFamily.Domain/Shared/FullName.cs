﻿using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public record FullName
{
    private FullName(
        string firstName,
        string middleName,
        string lastName)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
    }

    public string FirstName { get; } = default!;
    public string MiddleName { get; } = default!;
    public string LastName { get; } = default!;

    public static Result<FullName, Error> Create(
    string firstName,
    string middleName,
    string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || firstName.Count() > Constants.MAX_FIRST_NAME_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("FullName.firstName");
        }

        if (string.IsNullOrWhiteSpace(middleName) || middleName.Count() > Constants.MAX_NAME_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("FullName.middleName");
        }

        if (string.IsNullOrWhiteSpace(lastName) || lastName.Count() > Constants.MAX_LAST_NAME_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("FullName.lastName");
        }

        return new FullName(firstName, middleName, lastName);
    }
}