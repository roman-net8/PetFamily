﻿using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared.ValueObjects;

public record PetAttributes
{
    private PetAttributes(double weight, double height)
    {
        Weight = weight;
        Height = height;
    }

    public double Weight { get; } = default!;
    public double Height { get; } = default!;

    public static Result<PetAttributes, Error> Create(double weight, double height)
    {
        if (weight < 0)
        {
            return Errors.General.ValueIsInvalid("Weight");
        }

        if (height < 0)
        {
            return Errors.General.ValueIsInvalid("Height");
        }

        return new PetAttributes(weight, height);
    }
};