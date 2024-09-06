namespace PetFamily.Domain.Models.Pets;

public record PetPhotoList
{
    private PetPhotoList()
    {
    }

    public PetPhotoList(IEnumerable<PetPhoto> value)
    {
        Value = value.ToList();
    }

    public IReadOnlyList<PetPhoto> Value { get; }
};
