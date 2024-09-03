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

        builder.ComplexProperty(p => p.NickName, db =>
        {
            db.Property(d => d.Value)
                .HasMaxLength(Constants.MAX_NAME_TEXT_LENGTH)
                .HasColumnName("nick_name")
                .IsRequired();
        });

        builder.ComplexProperty(p => p.Description, db =>
        {
            db.Property(d => d.Value)
                .HasMaxLength(Constants.MAX_DESCRIPTION_TEXT_LENGTH)
                .HasColumnName("description")
                .IsRequired();
        });

        builder.ComplexProperty(p => p.Color, db =>
        {
            db.Property(d => d.Value)
                .HasMaxLength(Constants.MAX_PET_COLOR_TEXT_LENGTH)
                .HasColumnName("color")
                .IsRequired();
        });

        builder.ComplexProperty(p => p.HealthInfo, db =>
        {
            db.Property(d => d.Value)
                .HasMaxLength(Constants.MAX_PET_HEALTH_TEXT_LENGTH)
                .HasColumnName("health_info")
                .IsRequired();
        });

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
            .HasColumnName("appartment_number");
        });

        builder.ComplexProperty(p => p.PetAttributes, pb =>
        {
            pb.Property(a => a.Height)
            .IsRequired()
            .HasColumnName("height");

            pb.Property(a => a.Weight)
            .IsRequired()
            .HasColumnName("weight");
        });

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

        builder.OwnsOne(p => p.PetRequisites, pb =>
        {
            pb.ToJson("requisites_list");

            pb.OwnsMany(details => details.PetRequisiteList, pbr =>
            {
                pbr.Property(r => r.Title)
                       .IsRequired()
                       .HasMaxLength(Constants.MAX_TITLE_TEXT_LENGTH);

                pbr.Property(r => r.Description)
                   .IsRequired()
                   .HasMaxLength(Constants.MAX_DESCRIPTION_TEXT_LENGTH);
            });
        });

        builder.OwnsOne(p => p.Photos, pb =>
        {
            pb.ToJson("photos_list");

            pb.OwnsMany(b => b.Value, bp =>
            {
                bp
                    .Property(i => i.StoragePath)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_PATH_TEXT_LENGTH);

                bp.Property(i => i.IsMainPhoto).IsRequired();
            });
        });

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
