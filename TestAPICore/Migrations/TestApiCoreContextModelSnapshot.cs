﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestAPICore.Models;

namespace TestAPICore.Migrations
{
    [DbContext(typeof(TestApiCoreContext))]
    partial class TestApiCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestAPICore.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Headline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("ArticleItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Date = new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Headline = "Eksperter: Det har nul effekt på smitten i Danmark at lukke grænsen nu",
                            Text = "Tidligere direktør for Sundhedsstyrelsen kritiserer historisk beslutning om at lukke de danske grænser. Det er uklart, hvilke anbefalinger regeringen har bygget beslutningen om at lukke grænserne på."
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 4,
                            Date = new DateTime(1979, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Headline = "The Hitchhiker's Guide to the Galaxy",
                            Text = "econds before the Earth is demolished to make way for a galactic freeway, Arthur Dent is plucked off the planet by his friend Ford Prefect, a researcher for the revised edition of The Hitchhiker's Guide to the Galaxy who, for the last fifteen years, has been posing as an out-of-work actor."
                        });
                });

            modelBuilder.Entity("TestAPICore.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthorItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "George",
                            LastName = "RR Martin"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Stephen",
                            LastName = "Fry"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "James",
                            LastName = "Elroy"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Douglas",
                            LastName = "Adams"
                        });
                });

            modelBuilder.Entity("TestAPICore.Models.Article", b =>
                {
                    b.HasOne("TestAPICore.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
