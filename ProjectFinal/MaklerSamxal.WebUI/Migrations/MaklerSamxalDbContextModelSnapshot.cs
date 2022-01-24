﻿// <auto-generated />
using System;
using MaklerSamxal.WebUI.Models.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MaklerSamxal.WebUI.Migrations
{
    [DbContext(typeof(MaklerSamxalDbContext))]
    partial class MaklerSamxalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreateByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateData")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteData")
                        .HasColumnType("datetime2");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Linkedin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreateByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateData")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeleteByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteData")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.BlogPostComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogPostId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreateByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateData")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteData")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.HasIndex("ParentId");

                    b.ToTable("BlogPostComments");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AnswerByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AnswerData")
                        .HasColumnType("datetime2");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreateByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateData")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteData")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("Roles", "Membership");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "Membership");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Activates")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
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

                    b.ToTable("Users", "Membership");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "Membership");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "Membership");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "Membership");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUserToken", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "Membership");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Baths")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreateByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateData")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteData")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShopDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sqft")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Subscrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreateByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateData")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeleteByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteData")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EmailConfirmedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.ToTable("Subscrices");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Testimionals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreateByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateData")
                        .HasColumnType("datetime2");

                    b.Property<string>("Customer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeleteByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteData")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DeleteByUserId");

                    b.ToTable("Testimionalss");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Agent", b =>
                {
                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");

                    b.Navigation("CreateByUser");

                    b.Navigation("DeleteByUser");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Blog", b =>
                {
                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");

                    b.Navigation("CreateByUser");

                    b.Navigation("DeleteByUser");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.BlogPostComment", b =>
                {
                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Blog", "BlogPost")
                        .WithMany()
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");

                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.BlogPostComment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("BlogPost");

                    b.Navigation("CreateByUser");

                    b.Navigation("DeleteByUser");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Contact", b =>
                {
                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");

                    b.Navigation("CreateByUser");

                    b.Navigation("DeleteByUser");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerRoleClaim", b =>
                {
                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUserClaim", b =>
                {
                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUserLogin", b =>
                {
                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUserRole", b =>
                {
                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUserToken", b =>
                {
                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Product", b =>
                {
                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");

                    b.Navigation("CreateByUser");

                    b.Navigation("DeleteByUser");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Subscrice", b =>
                {
                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");

                    b.Navigation("CreateByUser");

                    b.Navigation("DeleteByUser");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.Testimionals", b =>
                {
                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("MaklerSamxal.WebUI.Models.Entity.Membership.MaklerUser", "DeleteByUser")
                        .WithMany()
                        .HasForeignKey("DeleteByUserId");

                    b.Navigation("CreateByUser");

                    b.Navigation("DeleteByUser");
                });

            modelBuilder.Entity("MaklerSamxal.WebUI.Models.Entity.BlogPostComment", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
