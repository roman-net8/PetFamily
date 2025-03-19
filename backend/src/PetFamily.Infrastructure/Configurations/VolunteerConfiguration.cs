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

        builder.ComplexProperty(v => v.PhoneNumber, vb =>
        {
            vb.Property(n => n.Value)
                .HasMaxLength(Constants.MAX_PHONE_TEXT_LENGTH)
                .HasColumnName("phone_number")
                .IsRequired();
        });

        builder.ComplexProperty(v => v.Email, vb =>
        {
            vb.Property(e => e.Value)
                .HasMaxLength(Constants.MAX_EMAIL_TEXT_LENGTH)
                .HasColumnName("email")
                .IsRequired();
        });

        builder.ComplexProperty(v => v.Description, vb =>
        {
            vb.Property(d => d.Value)
                .HasMaxLength(Constants.MAX_DESCRIPTION_TEXT_LENGTH)
                .HasColumnName("description")
                .IsRequired();
        });

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
                     .HasMaxLength(Constants.MAX_TITLE_TEXT_LENGTH);

                vrb.Property(r => r.Description)
                      .IsRequired()
                      .HasMaxLength(Constants.MAX_DESCRIPTION_TEXT_LENGTH);
            });

            vb.OwnsMany(details => details.Addresses, vab =>
            {
                vab.Property(r => r.Country)
                     .IsRequired()
                     .HasMaxLength(Constants.MAX_ADDRESS_TEXT_LENGTH);

                vab.Property(r => r.City)
                      .IsRequired()
                      .HasMaxLength(Constants.MAX_ADDRESS_TEXT_LENGTH);

                vab.Property(r => r.Street)
                      .IsRequired()
                      .HasMaxLength(Constants.MAX_ADDRESS_TEXT_LENGTH);

                vab.Property(r => r.HouseNumber)
                      .IsRequired()
                      .HasMaxLength(Constants.MIN_ADDRESS_TEXT_LENGTH);

                vab.Property(r => r.AppartmentNumber)
                      .IsRequired()
                      .HasMaxLength(Constants.MIN_ADDRESS_TEXT_LENGTH);
            });

        });

        builder.HasMany(v => v.Pets)
            .WithOne()
             .HasForeignKey("volunteer_id")
             .OnDelete(DeleteBehavior.Cascade);

        //указываем что при получение данных из табл volunteer добавлялась через InnerJoin данные из Pets
      //  builder.Navigation(v => v.Pets).AutoInclude();

        builder.Property<bool>("_isDeleted")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("is_deleted");

    }
}