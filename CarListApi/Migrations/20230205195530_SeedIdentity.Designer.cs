﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarListApi.Migrations
{
    [DbContext(typeof(CarListDbContext))]
    [Migration("20230205195530_SeedIdentity")]
    partial class SeedIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Toyota",
                            Model = "Hilux",
                            Vin = "29d5f82b-d851-4cce-98aa-a02487b5af38"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Suzuki",
                            Model = "Jimny",
                            Vin = "b4deb577-91ff-468e-a666-1b49766b35ed"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Honda",
                            Model = "Pilot",
                            Vin = "108dd979-1bf2-45e7-85f3-d61d56cc6442"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Subaru",
                            Model = "Impreza",
                            Vin = "369a98f3-7b50-46c3-be6f-780739df01a9"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Opel",
                            Model = "Astra",
                            Vin = "79072114-a629-41be-8a37-e712f75a8f3a"
                        },
                        new
                        {
                            Id = 6,
                            Brand = "Mercedes Benz",
                            Model = "C Klasse",
                            Vin = "b5dbb743-493e-4141-bb40-5d03498f8f91"
                        },
                        new
                        {
                            Id = 7,
                            Brand = "Tesla",
                            Model = "Model X",
                            Vin = "a0f40304-dc1e-4098-9734-ddc482896871"
                        },
                        new
                        {
                            Id = 8,
                            Brand = "Jeep",
                            Model = "Patriot",
                            Vin = "5a4265c8-d94b-428f-9165-f35bc0c1d68e"
                        },
                        new
                        {
                            Id = 9,
                            Brand = "Honda",
                            Model = "Prelude",
                            Vin = "e430c71e-4ea4-4de3-9e8c-14e3d1a31f52"
                        },
                        new
                        {
                            Id = 10,
                            Brand = "Mazda",
                            Model = "MX-5",
                            Vin = "9609b06b-0d1c-4ee9-9f40-0f720cc8b4af"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "e309462e-5b1f-4a7b-9fcd-539669205329",
                            ConcurrencyStamp = "353bc40b-d9bf-46a2-9f22-1a8319d33f30",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "e9a8b44b-6b74-426e-a26f-87214c179252",
                            ConcurrencyStamp = "37acabc8-0198-4c15-8dbe-35f9711dc468",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ec1e09b0-82ee-4c88-a736-8a62c13aa63b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e306f655-7964-4eb6-8ada-5e101ca5b6a5",
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEDdXS9U0DK9oGI7nbkMU/gpoq3NF8OySGUt1f64QbTug4MRqxzzQw0CNie6Sjr+FiQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "23573e84-e9b8-459f-9911-8cf7a602cf34",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = "cd7a8e1b-c4f7-4dc9-8431-d8d1a7461c0d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9ff73f79-6711-4af9-ae04-165c8e45dee7",
                            Email = "user@localhost.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@LOCALHOST.COM",
                            NormalizedUserName = "USER@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBi7c0loQOzWcmWI+hvCM9kDRtgOkOsvnK+T3nSnH+uA2YlHFD9eJzlMqL+OtaiOQQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6337dc92-15a1-4024-a200-18281bac8e4e",
                            TwoFactorEnabled = false
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "ec1e09b0-82ee-4c88-a736-8a62c13aa63b",
                            RoleId = "e309462e-5b1f-4a7b-9fcd-539669205329"
                        },
                        new
                        {
                            UserId = "cd7a8e1b-c4f7-4dc9-8431-d8d1a7461c0d",
                            RoleId = "e9a8b44b-6b74-426e-a26f-87214c179252"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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
#pragma warning restore 612, 618
        }
    }
}