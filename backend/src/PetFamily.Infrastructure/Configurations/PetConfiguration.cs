using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models.Pets;
using Constants = PetFamily.Domain.Shared.Constants;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
            id => id.Value,
            value => PetId.Create(value));

        builder.Property(p => p.Name)
             .IsRequired()
            .HasMaxLength(Constants.PetConst.MAX_NAME_TEXT_LENGTH);

        builder.Property(p => p.Type)
            .IsRequired()
            .HasMaxLength(Constants.PetConst.MAX_TYPE_TEXT_LENGTH);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(Constants.PetConst.MAX_DESCRIPTION_TEXT_LENGTH);

        builder.Property(p => p.Breed)
            .IsRequired()
            .HasMaxLength(Constants.PetConst.MAX_BREED_TEXT_LENGTH);

        builder.Property(p => p.Color)
            .IsRequired()
            .HasMaxLength(Constants.PetConst.MAX_COLOR_TEXT_LENGTH);

        builder.Property(p => p.Health)
            .IsRequired()
            .HasMaxLength(Constants.PetConst.MAX_HEALTH_TEXT_LENGTH);

        builder.Property(p => p.Weight)
          .IsRequired();

        builder.Property(p => p.Height)
            .IsRequired();

        builder.Property(p => p.OwnerPhone)
            .IsRequired()
            .HasMaxLength(Constants.PetConst.MAX_OWNER_PHONE_TEXT_LENGTH);

        builder.Property(p => p.IsCastrated)
          .IsRequired();

        builder.Property(p => p.IsVaccinated)
            .IsRequired();

        builder.Property(p => p.DateOfBirth)
          .IsRequired();

        builder.Property(p => p.CreatedDate)
          .IsRequired();

        builder.Property(p => p.HelpStatus)
         .IsRequired();

        builder.OwnsMany(p => p.Requisites)
            .ToJson();

        builder.HasMany(p => p.Photos)
            .WithOne()
            .HasForeignKey("pet_id")
          .OnDelete(DeleteBehavior.NoAction);
    }
}
