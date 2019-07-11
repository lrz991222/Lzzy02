﻿// <auto-generated />
using System;
using ELearning.ORM.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ELearning.ORM.Migrations
{
    [DbContext(typeof(SqlServerDbContext))]
    partial class SqlServerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ELearning.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityName");

                    b.Property<string>("Province");

                    b.Property<Guid?>("ThemeId");

                    b.HasKey("Id");

                    b.HasIndex("ThemeId");

                    b.ToTable("Citys");
                });

            modelBuilder.Entity("ELearning.Entities.Follow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CoverPersonId");

                    b.Property<Guid?>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("CoverPersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("Follow");
                });

            modelBuilder.Entity("ELearning.Entities.GoWith", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CityId");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("GowithContent");

                    b.Property<string>("GowithSynopsis");

                    b.Property<string>("GowithTitle");

                    b.Property<string>("Image");

                    b.Property<int>("Num");

                    b.Property<Guid?>("PersonId");

                    b.Property<string>("Tel");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("PersonId");

                    b.ToTable("GoWith");
                });

            modelBuilder.Entity("ELearning.Entities.GoWithMenber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Explain");

                    b.Property<Guid?>("GoWithId");

                    b.Property<Guid?>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("GoWithId");

                    b.HasIndex("PersonId");

                    b.ToTable("GoWithMenber");
                });

            modelBuilder.Entity("ELearning.Entities.Label", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LabelName");

                    b.HasKey("Id");

                    b.ToTable("Label");
                });

            modelBuilder.Entity("ELearning.Entities.Reply", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<int>("Like");

                    b.Property<Guid?>("ParentReplyId");

                    b.Property<Guid?>("PersonId");

                    b.Property<DateTime>("ReplyTime");

                    b.Property<Guid?>("TravelsID");

                    b.HasKey("Id");

                    b.HasIndex("ParentReplyId");

                    b.HasIndex("PersonId");

                    b.HasIndex("TravelsID");

                    b.ToTable("Reply");
                });

            modelBuilder.Entity("ELearning.Entities.ScenicSpot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Addr");

                    b.Property<string>("Describe");

                    b.Property<string>("Grade");

                    b.Property<Guid?>("LabelId");

                    b.Property<double>("Lat");

                    b.Property<double>("Lng");

                    b.Property<string>("Name");

                    b.Property<string>("Opentime");

                    b.Property<int>("Tel");

                    b.Property<Guid?>("ThemeId");

                    b.Property<string>("Type");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("LabelId");

                    b.HasIndex("ThemeId");

                    b.ToTable("ScenicSpot");
                });

            modelBuilder.Entity("ELearning.Entities.Theme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("themeName");

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("ELearning.Entities.TravelNotes", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Images");

                    b.Property<string>("Notos");

                    b.Property<Guid>("TravelsID");

                    b.HasKey("ID");

                    b.HasIndex("TravelsID");

                    b.ToTable("TravelNotes");
                });

            modelBuilder.Entity("ELearning.Entities.Travels", b =>
                {
                    b.Property<Guid>("TravelsID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Collection");

                    b.Property<int>("Like");

                    b.Property<int>("Share");

                    b.Property<DateTime>("TravelsTime");

                    b.Property<string>("TravelsTitle");

                    b.Property<Guid?>("UserId");

                    b.HasKey("TravelsID");

                    b.HasIndex("UserId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("ELearning.UserAndRole.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationRoleType");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DisplayName")
                        .HasMaxLength(20);

                    b.Property<bool>("IsDefaultRole");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<string>("Synopsis")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ELearning.UserAndRole.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("HerdPortrait");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name")
                        .HasMaxLength(30);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<long>("Phone");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("Sex");

                    b.Property<string>("Synopsis");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ELearning.Entities.City", b =>
                {
                    b.HasOne("ELearning.Entities.Theme", "Theme")
                        .WithMany()
                        .HasForeignKey("ThemeId");
                });

            modelBuilder.Entity("ELearning.Entities.Follow", b =>
                {
                    b.HasOne("ELearning.UserAndRole.ApplicationUser", "CoverPerson")
                        .WithMany()
                        .HasForeignKey("CoverPersonId");

                    b.HasOne("ELearning.UserAndRole.ApplicationUser", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("ELearning.Entities.GoWith", b =>
                {
                    b.HasOne("ELearning.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("ELearning.UserAndRole.ApplicationUser", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("ELearning.Entities.GoWithMenber", b =>
                {
                    b.HasOne("ELearning.Entities.GoWith", "GoWith")
                        .WithMany()
                        .HasForeignKey("GoWithId");

                    b.HasOne("ELearning.UserAndRole.ApplicationUser", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("ELearning.Entities.Reply", b =>
                {
                    b.HasOne("ELearning.Entities.Reply", "ParentReply")
                        .WithMany()
                        .HasForeignKey("ParentReplyId");

                    b.HasOne("ELearning.UserAndRole.ApplicationUser", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("ELearning.Entities.Travels", "Travels")
                        .WithMany()
                        .HasForeignKey("TravelsID");
                });

            modelBuilder.Entity("ELearning.Entities.ScenicSpot", b =>
                {
                    b.HasOne("ELearning.Entities.Label", "Label")
                        .WithMany()
                        .HasForeignKey("LabelId");

                    b.HasOne("ELearning.Entities.Theme", "Theme")
                        .WithMany()
                        .HasForeignKey("ThemeId");
                });

            modelBuilder.Entity("ELearning.Entities.TravelNotes", b =>
                {
                    b.HasOne("ELearning.Entities.Travels", "Travels")
                        .WithMany("TravelNotes")
                        .HasForeignKey("TravelsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ELearning.Entities.Travels", b =>
                {
                    b.HasOne("ELearning.UserAndRole.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("ELearning.UserAndRole.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("ELearning.UserAndRole.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("ELearning.UserAndRole.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("ELearning.UserAndRole.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ELearning.UserAndRole.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("ELearning.UserAndRole.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
