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
            .HasMaxLength(Constants.MAX_NAME_TEXT_LENGTH);

        builder.Property(p => p.Type)
            .IsRequired()
            .HasMaxLength(Constants.MAX_PET_TYPE_TEXT_LENGTH);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_DESCRIPTION_TEXT_LENGTH);

        builder.Property(p => p.Breed)
            .IsRequired()
            .HasMaxLength(Constants.MAX_BREED_TEXT_LENGTH);

        builder.Property(p => p.Color)
            .IsRequired()
            .HasMaxLength(Constants.MAX_PET_COLOR_TEXT_LENGTH);

        builder.Property(p => p.Health)
            .IsRequired()
            .HasMaxLength(Constants.MAX_PET_HEALTH_TEXT_LENGTH);

        builder.ComplexProperty(p => p.Address, pb =>
            {
                pb.Property(a => a.Country)
                .IsRequired()
                .HasColumnName("country");

                pb.Property(a => a.City)
                .IsRequired()
                .HasColumnName("city");

                pb.Property(a => a.Street)
                .IsRequired()
                .HasColumnName("street");

                pb.Property(a => a.HouseNumber)
                .IsRequired()
                .HasColumnName("house");

                pb.Property(a => a.AppartmentNumber)
                .IsRequired()
                .HasColumnName("appartment");
            });

        builder.Property(p => p.Weight)
          .IsRequired();

        builder.Property(p => p.Height)
            .IsRequired();

        builder.Property(p => p.OwnerPhone)
            .IsRequired()
            .HasMaxLength(Constants.MAX_PHONE_TEXT_LENGTH);

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

        builder.OwnsOne(p => p.Details, pb =>
        {
            pb.ToJson("details_list");

            pb.OwnsMany(details => details.PetRequisites, pbr =>
            {
                pbr.Property(r => r.Title)
                       .IsRequired()
                       .HasMaxLength(Constants.MAX_TITLE_TEXT_LENGTH);

                pbr.Property(r => r.Description)
                   .IsRequired()
                   .HasMaxLength(Constants.MAX_DESCRIPTION_TEXT_LENGTH);
            });
        });

        builder.HasMany(p => p.Photos)
            .WithOne()
            .HasForeignKey("pet_id") 
            .OnDelete(DeleteBehavior.NoAction);

        builder.ComplexProperty(p => p.SpeciesBreed,
           pb =>
           {
               pb.Property(s => s.SpeciesId)
               .HasConversion(
                   id => id.Value,
                   value => SpeciesId.Create(value))
               .IsRequired()
               .HasColumnName("species_id");

               pb.Property(s => s.BreedId)
               .HasConversion(
                   id => id.Value,
                   value => BreedId.Create(value))
               .IsRequired()
               .HasColumnName("breed_id");
           });

    }
}
