using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;

public class PetPhoto : Shared.Entity<PetPhotoId>
{
    //For EF Сore
    private PetPhoto(PetPhotoId id) : base(id)
    {
    }

    public PetPhoto(PetPhotoId id, string storagePath, bool isMain) : base(id)
    {
        StoragePath = storagePath;
        IsMain = isMain;
    }

    public string StoragePath { get; } = default!;
    public bool IsMain { get; }

    public static Result<PetPhoto, Error> Create(PetPhotoId id, string storagePath, bool isMain)
    {
        if (string.IsNullOrWhiteSpace(storagePath) || storagePath.Length > Constants.MAX_PATH_TEXT_LENGTH)
        {
            return Errors.General.ValueIsEmpty(nameof(Path));
        }

        return new PetPhoto(id, storagePath, isMain);
    }
}