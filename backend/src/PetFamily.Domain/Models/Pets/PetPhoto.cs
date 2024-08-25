using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;

public class PetPhoto : Entity<PetPhotoId>
{
    private PetPhoto(PetPhotoId id) : base(id) { }
    public string StoragePath { get; } = default!;
    public bool IsMain { get; }
}