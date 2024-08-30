using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configurations;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> b)
    {
        b.ToTable("breed");

        b.HasKey(bb => bb.Id);

        b.Property(bb =>bb.Id)
            .HasConversion(
                id => id.Value,
                id => BreedId.Create(id));

        b.Property(x => x.Name)
            .HasMaxLength(Constants.MAX_BREED_TEXT_LENGTH);
    }
}

