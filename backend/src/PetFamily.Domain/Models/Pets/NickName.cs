using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;

public record NickName
{
    public string Value { get; }

    private NickName(string value)
    {
        Value = value;
    }

    public static Result<NickName, Error> Create(string nickName)
    {
        if (string.IsNullOrWhiteSpace(nickName) || nickName.Length > Constants.MAX_FIRST_NAME_TEXT_LENGTH)
            return Errors.General.ValueIsInvalid("NickName");

        return new NickName(nickName);
    }
}
