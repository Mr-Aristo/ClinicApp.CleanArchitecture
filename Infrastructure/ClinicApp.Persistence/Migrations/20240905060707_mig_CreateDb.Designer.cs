﻿// <auto-generated />
using System;
using ClinicApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicApp.Persistence.Migrations
{
    [DbContext(typeof(ClinicAppContext))]
    [Migration("20240905060707_mig_CreateDb")]
    partial class mig_CreateDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClinicApp.Domain.Entities.Cabines", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Cabines");
                });

            modelBuilder.Entity("ClinicApp.Domain.Entities.Doctors", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Cabine")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CabinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SectionsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpecializationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpecializationsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CabinesId");

                    b.HasIndex("SectionsId");

                    b.HasIndex("SpecializationsId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ClinicApp.Domain.Entities.Patients", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SectionsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SectionsId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("ClinicApp.Domain.Entities.Sections", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("ClinicApp.Domain.Entities.Specializations", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("ClinicApp.Domain.Entities.Doctors", b =>
                {
                    b.HasOne("ClinicApp.Domain.Entities.Cabines", "Cabines")
                        .WithMany("Doctors")
                        .HasForeignKey("CabinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicApp.Domain.Entities.Sections", "Sections")
                        .WithMany("Doctors")
                        .HasForeignKey("SectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicApp.Domain.Entities.Specializations", "Specializations")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabines");

                    b.Navigation("Sections");

                    b.Navigation("Specializations");
                });

            modelBuilder.Entity("ClinicApp.Domain.Entities.Patients", b =>
                {
                    b.HasOne("ClinicApp.Domain.Entities.Sections", "Sections")
                        .WithMany("Patients")
                        .HasForeignKey("SectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sections");
                });

            modelBuilder.Entity("ClinicApp.Domain.Entities.Cabines", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("ClinicApp.Domain.Entities.Sections", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("ClinicApp.Domain.Entities.Specializations", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
