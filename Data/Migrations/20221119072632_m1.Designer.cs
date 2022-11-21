﻿// <auto-generated />
using System;
using Assignment1_v3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment1_v3.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221119072632_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignment1_v3.Models.Feedback", b =>
                {
                    b.Property<Guid>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Message")
                        .HasColumnType("int");

                    b.Property<Guid?>("ResolutionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FeedbackId");

                    b.HasIndex("ResolutionId");

                    b.HasIndex("UserId");

                    b.ToTable("Feedbacks");

                    b.HasData(
                        new
                        {
                            FeedbackId = new Guid("a32d462e-bd7b-4ba4-8a41-4439869ef844"),
                            Link = "www.google.ca",
                            Message = 0,
                            ResolutionId = new Guid("ec7bf106-f607-4f33-aba8-aa2001c0073b"),
                            UserId = "6af8ed9c-0bac-40ac-aff2-f5d005dced65"
                        },
                        new
                        {
                            FeedbackId = new Guid("c906addc-3edb-4803-aa1a-a5c2ce1f32c3"),
                            Link = "www.apple.ca",
                            Message = 1,
                            ResolutionId = new Guid("a69d7016-23c5-4520-ab41-bf4167c3866e"),
                            UserId = "fda8e4f5-6011-4f3b-9677-7eb8872e9f82"
                        },
                        new
                        {
                            FeedbackId = new Guid("4c1131d8-e45b-458b-a153-31aa3b933151"),
                            Link = "www.microsoft.ca",
                            Message = 0,
                            ResolutionId = new Guid("48342a2b-4c07-4b19-8c52-9cd2077edb35"),
                            UserId = "31432085-85bc-4648-8a82-e8ff8b5671cc"
                        },
                        new
                        {
                            FeedbackId = new Guid("5e502112-f9ae-4339-98d6-ae24b14917a6"),
                            Link = "www.amazon.ca",
                            Message = 1,
                            ResolutionId = new Guid("ad483ad4-d93c-4b8f-b524-98316aad19a6"),
                            UserId = "a41390e5-790c-488f-8639-1db213da8375"
                        });
                });

            modelBuilder.Entity("Assignment1_v3.Models.Resolution", b =>
                {
                    b.Property<Guid>("ResolutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("ResolutionAbstract")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ResolutionId");

                    b.HasIndex("UserId");

                    b.ToTable("Resolutions");

                    b.HasData(
                        new
                        {
                            ResolutionId = new Guid("ec7bf106-f607-4f33-aba8-aa2001c0073b"),
                            ResolutionAbstract = "Abstract1",
                            Status = 0,
                            UserId = "6af8ed9c-0bac-40ac-aff2-f5d005dced65"
                        },
                        new
                        {
                            ResolutionId = new Guid("a69d7016-23c5-4520-ab41-bf4167c3866e"),
                            ResolutionAbstract = "Abstract2",
                            Status = 1,
                            UserId = "fda8e4f5-6011-4f3b-9677-7eb8872e9f82"
                        },
                        new
                        {
                            ResolutionId = new Guid("48342a2b-4c07-4b19-8c52-9cd2077edb35"),
                            ResolutionAbstract = "Abstract3",
                            Status = 2,
                            UserId = "31432085-85bc-4648-8a82-e8ff8b5671cc"
                        },
                        new
                        {
                            ResolutionId = new Guid("ad483ad4-d93c-4b8f-b524-98316aad19a6"),
                            ResolutionAbstract = "Abstract4",
                            Status = 3,
                            UserId = "a41390e5-790c-488f-8639-1db213da8375"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "cd615706-9af4-4d4e-8212-b9a45de28a6f",
                            ConcurrencyStamp = "a1ee65e8-f37c-4a29-b456-1d3d1c3c6cdc",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "a934212f-941e-4150-80ac-d675fbd79dde",
                            ConcurrencyStamp = "94373447-5760-4c73-a702-433248762bcc",
                            Name = "Member",
                            NormalizedName = "MEMBER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "9dc5073e-28a1-40ab-ad05-4da15c3692a3",
                            RoleId = "cd615706-9af4-4d4e-8212-b9a45de28a6f"
                        },
                        new
                        {
                            UserId = "6af8ed9c-0bac-40ac-aff2-f5d005dced65",
                            RoleId = "a934212f-941e-4150-80ac-d675fbd79dde"
                        },
                        new
                        {
                            UserId = "fda8e4f5-6011-4f3b-9677-7eb8872e9f82",
                            RoleId = "a934212f-941e-4150-80ac-d675fbd79dde"
                        },
                        new
                        {
                            UserId = "31432085-85bc-4648-8a82-e8ff8b5671cc",
                            RoleId = "a934212f-941e-4150-80ac-d675fbd79dde"
                        },
                        new
                        {
                            UserId = "a41390e5-790c-488f-8639-1db213da8375",
                            RoleId = "a934212f-941e-4150-80ac-d675fbd79dde"
                        },
                        new
                        {
                            UserId = "4bb81b94-441b-43ee-bb4a-ee8ebeb50fdf",
                            RoleId = "a934212f-941e-4150-80ac-d675fbd79dde"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Assignment1_v3.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SignatureGUID")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "9dc5073e-28a1-40ab-ad05-4da15c3692a3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ca645e1e-c3c1-4197-aeec-103bb56ce5a5",
                            Email = "aa@aa.aa",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "AA@AA.AA",
                            PasswordHash = "AQAAAAEAACcQAAAAEHe0IXk2qmJ6tvGzP5t013H/wxiUNXsSFF7aTtAW+ybXJV49d2aewni1yhQNbxevKg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b245b190-94a9-4c02-882a-8dac354271ad",
                            TwoFactorEnabled = false,
                            UserName = "aa@aa.aa",
                            FirstName = "Admin",
                            LastName = "Administrator",
                            SignatureGUID = "1e0dd39e-7f7c-4432-a315-b86a9c888590"
                        },
                        new
                        {
                            Id = "6af8ed9c-0bac-40ac-aff2-f5d005dced65",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "820aeb2e-b534-4e4a-8758-83ed6144a2a0",
                            Email = "11@11.11",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "11@11.11",
                            PasswordHash = "AQAAAAEAACcQAAAAEN7h+3RRLoL6qpa/Hz/9a1XZJZc59NkVsl4TDNXz/E87stdQUzaSvYZ+6FnwK5EOpg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a06fb0e4-e47f-42f4-9e3d-9b9a1c33c94f",
                            TwoFactorEnabled = false,
                            UserName = "11@11.11",
                            FirstName = "Pat",
                            LastName = "John",
                            SignatureGUID = "20216312-7877-4654-b904-8e6e05b24892"
                        },
                        new
                        {
                            Id = "fda8e4f5-6011-4f3b-9677-7eb8872e9f82",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "71ba83a3-bafd-4825-91b3-0e6f0c8dd023",
                            Email = "22@22.22",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "22@22.22",
                            PasswordHash = "AQAAAAEAACcQAAAAEC+pVqz8bokNR/hZrCrRLdbUpLVOoRchx0GP4rpA9j4i83Yw+uE8cnmUpF8rlKFVdg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "78e3848b-9b28-4af5-8100-70a672b993de",
                            TwoFactorEnabled = false,
                            UserName = "22@22.22",
                            FirstName = "Sue",
                            LastName = "Fox",
                            SignatureGUID = "9b523f95-37ea-4d4f-b75c-670d70364c22"
                        },
                        new
                        {
                            Id = "31432085-85bc-4648-8a82-e8ff8b5671cc",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "104aecdd-d84e-4c01-a36f-e283c584dfd8",
                            Email = "33@33.33",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "33@33.33",
                            PasswordHash = "AQAAAAEAACcQAAAAEH6f4Pzr9xZwyfrrG8QFRAvIJrZILKCoaQtUdJ+Nq727dRVKIsgkhwFYe0pgLR/ETw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e0451bbb-3f9c-4f9f-9000-897d7cc9ee4c",
                            TwoFactorEnabled = false,
                            UserName = "33@33.33",
                            FirstName = "Bob",
                            LastName = "Sims",
                            SignatureGUID = "4c63e0f6-c9ab-48b0-b50a-6639d47e952c"
                        },
                        new
                        {
                            Id = "a41390e5-790c-488f-8639-1db213da8375",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "912bf26c-682f-4164-a9e3-34c0a4ad26fa",
                            Email = "44@44.44",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "44@44.44",
                            PasswordHash = "AQAAAAEAACcQAAAAEL5WCYGMci/BcdLEH1FRZJ0/mVpQznJPV6Cgx7OZjAL9Xcc7FnOaDXKBRuCHR/SbGQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "21a17c8f-654c-4666-9459-03077c711360",
                            TwoFactorEnabled = false,
                            UserName = "44@44.44",
                            FirstName = "Eddy",
                            LastName = "Glen",
                            SignatureGUID = "eef1de33-3751-4228-96f5-6fd6726da577"
                        },
                        new
                        {
                            Id = "4bb81b94-441b-43ee-bb4a-ee8ebeb50fdf",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "76551c69-c4eb-49c2-ace6-da0f139f9dbb",
                            Email = "comp4976@outlook.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "COMP4976@OUTLOOK.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEPY4rFRvX2w8NIuUfHtGWggwrTj7b/p/zzb51QcKcU2alokWMz5zA1TzuhDcnc4Z2w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "db72f978-4d8a-4e94-97c6-43fe886dce97",
                            TwoFactorEnabled = false,
                            UserName = "comp4976@outlook.com",
                            FirstName = "Medhat",
                            LastName = "Elmasry",
                            SignatureGUID = "56ece414-f78a-4087-8f0d-2c2a581ac65c"
                        });
                });

            modelBuilder.Entity("Assignment1_v3.Models.Feedback", b =>
                {
                    b.HasOne("Assignment1_v3.Models.Resolution", "Resolution")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ResolutionId");

                    b.HasOne("Assignment1_v3.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Resolution");
                });

            modelBuilder.Entity("Assignment1_v3.Models.Resolution", b =>
                {
                    b.HasOne("Assignment1_v3.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Resolutions")
                        .HasForeignKey("UserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment1_v3.Models.Resolution", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("Assignment1_v3.Models.ApplicationUser", b =>
                {
                    b.Navigation("Resolutions");
                });
#pragma warning restore 612, 618
        }
    }
}