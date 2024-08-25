using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configurations;

public class PetPhotoConfiguration : IEntityTypeConfiguration<PetPhoto>
{

    public void Configure(EntityTypeBuilder<PetPhoto> builder)
    {
        builder.ToTable("pet_photos");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(
            id => id.Value,
            value => PetPhotoId.Create(value));

        builder.Property(p => p.StoragePath)
             .IsRequired()
            .HasMaxLength(Constants.MAX_PATH_TEXT_LENGTH);


        builder.Property(p => p.IsMain)
            .IsRequired();
    }
}