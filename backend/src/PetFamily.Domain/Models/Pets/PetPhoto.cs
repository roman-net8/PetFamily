using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;

public class PetPhoto : Entity<PetPhotoId>
{
    private PetPhoto(PetPhotoId id, string storagePath, bool isMain) : base(id)
    {
        StoragePath = storagePath;
        IsMain = isMain;
    }

    private PetPhoto(PetPhotoId id) : base(id) { }
    public string StoragePath { get; } = default!;
    public bool IsMain { get; }

    public static Result<PetPhoto> Create(PetPhotoId id, string storagePath, bool isMain)
    {
        if (string.IsNullOrWhiteSpace(storagePath) || storagePath.Length > Constants.MAX_PATH_TEXT_LENGTH)
        {
            return Errors.General.ValueIsEmpty(nameof(Path));
        }

        return new PetPhoto(id, storagePath, isMain);
    }
}