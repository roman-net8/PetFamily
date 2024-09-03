using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;
public record PetPhoto
{
    private PetPhoto(string storagePath, bool isMainPhoto)
    {
        StoragePath = storagePath;
        IsMainPhoto = isMainPhoto;
    }

    public string StoragePath { get; }
    public bool IsMainPhoto { get; }

    public static Result<PetPhoto, Error> Create(string storagePath, bool isMainPhoto)
    {
        if (string.IsNullOrWhiteSpace(storagePath))
        {
            return Errors.General.ValueIsEmpty("StoragePath");
        }

        if (storagePath.Length > Constants.MAX_PATH_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalidLength("StoragePath");
        }
        return new PetPhoto(storagePath, isMainPhoto);
    }
}


