using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models.Volunteers;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteer");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id)
            .HasConversion(
                    id => id.Value,
                    value => VolunteerId.Create(value));
         
        builder.ComplexProperty(v => v.FullName, vb =>
        {
            vb.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_FIRST_NAME_TEXT_LENGTH);

            vb.Property(f => f.MiddleName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LAST_NAME_TEXT_LENGTH);

            vb.Property(f => f.LastName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LAST_NAME_TEXT_LENGTH);
        });


        builder.Property(v => v.Email)
            .IsRequired()
            .HasMaxLength(Constants.MAX_EMAIL_TEXT_LENGTH);

        builder.Property(v => v.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_DESCRIPTION_TEXT_LENGTH);

        builder.Property(v => v.YearsOfExperience)
            .IsRequired();

        builder.Property(v => v.Phone)
            .IsRequired()
            .HasMaxLength(Constants.MAX_PHONE_TEXT_LENGTH);

        builder.HasIndex(v => v.Phone)
             .IsUnique();

        builder.HasMany(v => v.OwnedPets)
             .WithOne()
             .HasForeignKey("volunteer_id");

        builder.OwnsOne(v => v.Details, vb =>
        {
            vb.ToJson("details_list");

            vb.OwnsMany(details => details.SocialNetworks, vsb =>
            {
                vsb.Property(s => s.UserName)
                       .IsRequired()
                       .HasMaxLength(Constants.MAX_NAME_TEXT_LENGTH);

                vsb.Property(s => s.Link)
                      .IsRequired()
                      .HasMaxLength(Constants.MAX_LINK_TEXT_LENGTH);

                vsb.Property(s => s.Description)
                      .IsRequired()
                      .HasMaxLength(Constants.MAX_DESCRIPTION_TEXT_LENGTH);
            });

            vb.OwnsMany(details => details.Requisites, vrb =>
            {
                vrb.Property(r => r.Title)
                     .IsRequired()
                     .HasMaxLength(Constants.MAX_NAME_TEXT_LENGTH);

                vrb.Property(r => r.Description)
                      .IsRequired()
                      .HasMaxLength(Constants.MAX_DESCRIPTION_TEXT_LENGTH);
            });

        });
    }
}
