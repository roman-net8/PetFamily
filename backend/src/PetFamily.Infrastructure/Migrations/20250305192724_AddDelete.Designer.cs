﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PetFamily.Infrastructure;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250305192724_AddDelete")]
    partial class AddDelete
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PetFamily.Domain.Models.Pets.Breed", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("name");

                    b.Property<Guid?>("species_id")
                        .HasColumnType("uuid")
                        .HasColumnName("species_id");

                    b.HasKey("Id")
                        .HasName("pk_breed");

                    b.HasIndex("species_id")
                        .HasDatabaseName("ix_breed_species_id");

                    b.ToTable("breed", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Models.Pets.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<int>("HelpStatus")
                        .HasColumnType("integer")
                        .HasColumnName("help_status");

                    b.Property<bool>("IsCastrated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_castrated");

                    b.Property<bool>("IsVaccinated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_vaccinated");

                    b.Property<bool>("_isDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<Guid?>("volunteer_id")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "PetFamily.Domain.Models.Pets.Pet.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("AppartmentNumber")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("appartment_number");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("country");

                            b1.Property<string>("HouseNumber")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("house");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("street");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Color", "PetFamily.Domain.Models.Pets.Pet.Color#Color", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(32)
                                .HasColumnType("character varying(32)")
                                .HasColumnName("color");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Description", "PetFamily.Domain.Models.Pets.Pet.Description#Description", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("description");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("HealthInfo", "PetFamily.Domain.Models.Pets.Pet.HealthInfo#HealthInfo", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("health_info");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("NickName", "PetFamily.Domain.Models.Pets.Pet.NickName#NickName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("character varying(128)")
                                .HasColumnName("nick_name");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PetAttributes", "PetFamily.Domain.Models.Pets.Pet.PetAttributes#PetAttributes", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<double>("Height")
                                .HasColumnType("double precision")
                                .HasColumnName("height");

                            b1.Property<double>("Weight")
                                .HasColumnType("double precision")
                                .HasColumnName("weight");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("SpeciesBreed", "PetFamily.Domain.Models.Pets.Pet.SpeciesBreed#SpeciesBreedType", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<Guid>("BreedId")
                                .HasColumnType("uuid")
                                .HasColumnName("breed_id");

                            b1.Property<Guid>("SpeciesId")
                                .HasColumnType("uuid")
                                .HasColumnName("species_id");
                        });

                    b.HasKey("Id")
                        .HasName("pk_pets");

                    b.HasIndex("volunteer_id")
                        .HasDatabaseName("ix_pets_volunteer_id");

                    b.ToTable("pets", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Models.Pets.Species", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_species");

                    b.ToTable("species", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Models.Volunteers.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("YearsOfExperience")
                        .HasColumnType("numeric")
                        .HasColumnName("years_of_experience");

                    b.Property<bool>("_isDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.ComplexProperty<Dictionary<string, object>>("Description", "PetFamily.Domain.Models.Volunteers.Volunteer.Description#Description", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("description");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Email", "PetFamily.Domain.Models.Volunteers.Volunteer.Email#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("character varying(128)")
                                .HasColumnName("email");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("FullName", "PetFamily.Domain.Models.Volunteers.Volunteer.FullName#FullName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(32)
                                .HasColumnType("character varying(32)")
                                .HasColumnName("full_name_first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(32)
                                .HasColumnType("character varying(32)")
                                .HasColumnName("full_name_last_name");

                            b1.Property<string>("MiddleName")
                                .IsRequired()
                                .HasMaxLength(32)
                                .HasColumnType("character varying(32)")
                                .HasColumnName("full_name_middle_name");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PhoneNumber", "PetFamily.Domain.Models.Volunteers.Volunteer.PhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("character varying(16)")
                                .HasColumnName("phone_number");
                        });

                    b.HasKey("Id")
                        .HasName("pk_volunteer");

                    b.ToTable("volunteer", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Models.Pets.Breed", b =>
                {
                    b.HasOne("PetFamily.Domain.Models.Pets.Species", null)
                        .WithMany("Breeds")
                        .HasForeignKey("species_id")
                        .HasConstraintName("fk_breed_species_species_id");
                });

            modelBuilder.Entity("PetFamily.Domain.Models.Pets.Pet", b =>
                {
                    b.HasOne("PetFamily.Domain.Models.Volunteers.Volunteer", null)
                        .WithMany("Pets")
                        .HasForeignKey("volunteer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_pets_volunteer_volunteer_id");

                    b.OwnsOne("PetFamily.Domain.Models.Pets.PetPhotoList", "PetPhotoList", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.HasKey("PetId");

                            b1.ToTable("pets");

                            b1.ToJson("photos_list");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pets_pets_id");

                            b1.OwnsMany("PetFamily.Domain.Models.Pets.PetPhoto", "Value", b2 =>
                                {
                                    b2.Property<Guid>("PetPhotoListPetId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<bool>("IsMainPhoto")
                                        .HasColumnType("boolean");

                                    b2.Property<string>("StoragePath")
                                        .IsRequired()
                                        .HasMaxLength(256)
                                        .HasColumnType("character varying(256)");

                                    b2.HasKey("PetPhotoListPetId", "Id")
                                        .HasName("pk_pets");

                                    b2.ToTable("pets");

                                    b2.WithOwner()
                                        .HasForeignKey("PetPhotoListPetId")
                                        .HasConstraintName("fk_pets_pets_pet_photo_list_pet_id");
                                });

                            b1.Navigation("Value");
                        });

                    b.OwnsOne("PetFamily.Domain.Models.Pets.PetRequisites", "PetRequisites", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.HasKey("PetId");

                            b1.ToTable("pets");

                            b1.ToJson("requisites_list");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pets_pets_id");

                            b1.OwnsMany("PetFamily.Domain.Shared.ValueObjects.Requisite", "PetRequisiteList", b2 =>
                                {
                                    b2.Property<Guid>("PetRequisitesPetId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(256)
                                        .HasColumnType("character varying(256)");

                                    b2.Property<string>("Title")
                                        .IsRequired()
                                        .HasMaxLength(128)
                                        .HasColumnType("character varying(128)");

                                    b2.HasKey("PetRequisitesPetId", "Id")
                                        .HasName("pk_pets");

                                    b2.ToTable("pets");

                                    b2.WithOwner()
                                        .HasForeignKey("PetRequisitesPetId")
                                        .HasConstraintName("fk_pets_pets_pet_requisites_pet_id");
                                });

                            b1.Navigation("PetRequisiteList");
                        });

                    b.Navigation("PetPhotoList")
                        .IsRequired();

                    b.Navigation("PetRequisites")
                        .IsRequired();
                });

            modelBuilder.Entity("PetFamily.Domain.Models.Volunteers.Volunteer", b =>
                {
                    b.OwnsOne("PetFamily.Domain.Models.Volunteers.VolunteerDetails", "Details", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.HasKey("VolunteerId");

                            b1.ToTable("volunteer");

                            b1.ToJson("details_list");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteer_volunteer_id");

                            b1.OwnsMany("PetFamily.Domain.Shared.ValueObjects.Requisite", "Requisites", b2 =>
                                {
                                    b2.Property<Guid>("VolunteerDetailsVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(256)
                                        .HasColumnType("character varying(256)");

                                    b2.Property<string>("Title")
                                        .IsRequired()
                                        .HasMaxLength(128)
                                        .HasColumnType("character varying(128)");

                                    b2.HasKey("VolunteerDetailsVolunteerId", "Id")
                                        .HasName("pk_volunteer");

                                    b2.ToTable("volunteer");

                                    b2.WithOwner()
                                        .HasForeignKey("VolunteerDetailsVolunteerId")
                                        .HasConstraintName("fk_volunteer_volunteer_volunteer_details_volunteer_id");
                                });

                            b1.OwnsMany("PetFamily.Domain.Shared.ValueObjects.Address", "Addresses", b2 =>
                                {
                                    b2.Property<Guid>("VolunteerDetailsVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("AppartmentNumber")
                                        .IsRequired()
                                        .HasMaxLength(16)
                                        .HasColumnType("character varying(16)");

                                    b2.Property<string>("City")
                                        .IsRequired()
                                        .HasMaxLength(256)
                                        .HasColumnType("character varying(256)");

                                    b2.Property<string>("Country")
                                        .IsRequired()
                                        .HasMaxLength(256)
                                        .HasColumnType("character varying(256)");

                                    b2.Property<string>("HouseNumber")
                                        .IsRequired()
                                        .HasMaxLength(16)
                                        .HasColumnType("character varying(16)");

                                    b2.Property<string>("Street")
                                        .IsRequired()
                                        .HasMaxLength(256)
                                        .HasColumnType("character varying(256)");

                                    b2.HasKey("VolunteerDetailsVolunteerId", "Id")
                                        .HasName("pk_volunteer");

                                    b2.ToTable("volunteer");

                                    b2.WithOwner()
                                        .HasForeignKey("VolunteerDetailsVolunteerId")
                                        .HasConstraintName("fk_volunteer_volunteer_volunteer_details_volunteer_id");
                                });

                            b1.OwnsMany("PetFamily.Domain.Shared.ValueObjects.SocialNetwork", "SocialNetworks", b2 =>
                                {
                                    b2.Property<Guid>("VolunteerDetailsVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(256)
                                        .HasColumnType("character varying(256)");

                                    b2.Property<string>("Link")
                                        .IsRequired()
                                        .HasMaxLength(512)
                                        .HasColumnType("character varying(512)");

                                    b2.Property<string>("UserName")
                                        .IsRequired()
                                        .HasMaxLength(128)
                                        .HasColumnType("character varying(128)");

                                    b2.HasKey("VolunteerDetailsVolunteerId", "Id")
                                        .HasName("pk_volunteer");

                                    b2.ToTable("volunteer");

                                    b2.WithOwner()
                                        .HasForeignKey("VolunteerDetailsVolunteerId")
                                        .HasConstraintName("fk_volunteer_volunteer_volunteer_details_volunteer_id");
                                });

                            b1.Navigation("Addresses");

                            b1.Navigation("Requisites");

                            b1.Navigation("SocialNetworks");
                        });

                    b.Navigation("Details")
                        .IsRequired();
                });

            modelBuilder.Entity("PetFamily.Domain.Models.Pets.Species", b =>
                {
                    b.Navigation("Breeds");
                });

            modelBuilder.Entity("PetFamily.Domain.Models.Volunteers.Volunteer", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
