// <auto-generated />
using BackEnd.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Back_End.Models.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Amsterdam"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            Name = "Berlin"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 3,
                            Name = "Copenhagen"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 4,
                            Name = "Dublin"
                        });
                });

            modelBuilder.Entity("Back_End.Models.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Holland"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Germany"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Denmark"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ireland"
                        });
                });

            modelBuilder.Entity("Back_End.Models.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dutch"
                        },
                        new
                        {
                            Id = 2,
                            Name = "German"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Danish"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Irish"
                        });
                });

            modelBuilder.Entity("Back_End.Models.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(48)")
                        .HasMaxLength(48);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "Alice",
                            PhoneNumber = "1234567890"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 2,
                            Name = "Bob",
                            PhoneNumber = "2345679801"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 3,
                            Name = "Carol",
                            PhoneNumber = "3456789012"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 4,
                            Name = "Dan",
                            PhoneNumber = "4567890123"
                        });
                });

            modelBuilder.Entity("Back_End.Models.Entities.PersonLanguage", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PeopleLanguages");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 2,
                            LanguageId = 2
                        },
                        new
                        {
                            PersonId = 3,
                            LanguageId = 3
                        },
                        new
                        {
                            PersonId = 4,
                            LanguageId = 4
                        });
                });

            modelBuilder.Entity("Back_End.Models.Entities.City", b =>
                {
                    b.HasOne("Back_End.Models.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_End.Models.Entities.Person", b =>
                {
                    b.HasOne("Back_End.Models.Entities.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_End.Models.Entities.PersonLanguage", b =>
                {
                    b.HasOne("Back_End.Models.Entities.Language", "Langauge")
                        .WithMany("PeopleLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_End.Models.Entities.Person", "Person")
                        .WithMany("PeopleLanguages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
