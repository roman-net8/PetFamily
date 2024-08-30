using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configurations;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> b)
    {
        b.ToTable("species");

        b.HasKey(s => s.Id);

        b.Property(s => s.Id)
                .HasConversion(
                id => id.Value,
                id => SpeciesId.Create(id));

        b.Property(sb => sb.Name)
            .HasMaxLength(Constants.MAX_PET_SPECIES_TEXT_LENGTH);

        b.HasMany(sb => sb.Breeds)
            .WithOne()
            .HasForeignKey("species_id");
    }
}
