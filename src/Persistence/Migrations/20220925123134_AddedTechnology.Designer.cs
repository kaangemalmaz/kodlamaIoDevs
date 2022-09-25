﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(KodlamaIoDevsDbContext))]
    [Migration("20220925123134_AddedTechnology")]
    partial class AddedTechnology
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.ProgramingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ProgramingLanguages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Python"
                        },
                        new
                        {
                            Id = 2,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Java"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Technology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("ProgramingLanguageId")
                        .HasColumnType("int")
                        .HasColumnName("ProgramingLanguageId");

                    b.HasKey("Id");

                    b.HasIndex("ProgramingLanguageId");

                    b.ToTable("Technologies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Java",
                            ProgramingLanguageId = 3
                        },
                        new
                        {
                            Id = 2,
                            Name = "C#",
                            ProgramingLanguageId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Django",
                            ProgramingLanguageId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Technology", b =>
                {
                    b.HasOne("Domain.Entities.ProgramingLanguage", "ProgramingLanguage")
                        .WithMany("Technologies")
                        .HasForeignKey("ProgramingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramingLanguage");
                });

            modelBuilder.Entity("Domain.Entities.ProgramingLanguage", b =>
                {
                    b.Navigation("Technologies");
                });
#pragma warning restore 612, 618
        }
    }
}