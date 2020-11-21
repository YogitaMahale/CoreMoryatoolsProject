﻿// <auto-generated />
using System;
using CoreMoryatools.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreMoryatools.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreMoryatools.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("field1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("field2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("longdescp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("seqno")
                        .HasColumnType("int");

                    b.Property<string>("shortdesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CoreMoryatools.Models.Expense", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Expense");
                });

            modelBuilder.Entity("CoreMoryatools.Models.bankmaster", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("accountholdername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("accountno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bankbranch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bankifsccode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bankname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("bankmaster");
                });

            modelBuilder.Entity("CoreMoryatools.Models.city", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("bit");

                    b.Property<int>("stateid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("stateid");

                    b.ToTable("city");
                });

            modelBuilder.Entity("CoreMoryatools.Models.country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("countrycode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("country");
                });

            modelBuilder.Entity("CoreMoryatools.Models.orderstatus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NotificationMsg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("orderstatus");
                });

            modelBuilder.Entity("CoreMoryatools.Models.product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HSNCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LandingPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("RealStock")
                        .HasColumnType("int");

                    b.Property<int>("alertquantites")
                        .HasColumnType("int");

                    b.Property<int>("cid")
                        .HasColumnType("int");

                    b.Property<DateTime>("createddate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("customerprice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("dealerprice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("discountprice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("gst")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("isHotproduct")
                        .HasColumnType("bit");

                    b.Property<bool>("isNewArrivalProduct")
                        .HasColumnType("bit");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<bool>("isdelete")
                        .HasColumnType("bit");

                    b.Property<bool>("isstock")
                        .HasColumnType("bit");

                    b.Property<string>("longdescp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mainimage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifieddate")
                        .HasColumnType("datetime2");

                    b.Property<string>("productname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantites")
                        .HasColumnType("int");

                    b.Property<int>("seqno")
                        .HasColumnType("int");

                    b.Property<string>("shortdescp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("superwholesaleprice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("video1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("video2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("video3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("video4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("video_name_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("video_name_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("video_name_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("video_name_4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("wholesaleprice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("cid");

                    b.ToTable("product");
                });

            modelBuilder.Entity("CoreMoryatools.Models.productimages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("imagename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isdelete")
                        .HasColumnType("bit");

                    b.Property<int>("pid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("pid");

                    b.ToTable("productimages");
                });

            modelBuilder.Entity("CoreMoryatools.Models.state", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("countryid")
                        .HasColumnType("int");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("countryid");

                    b.ToTable("state");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
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
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

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
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CoreMoryatools.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int>("FK_agentId")
                        .HasColumnType("int");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("cityid")
                        .HasColumnType("int");

                    b.Property<DateTime>("createddate")
                        .HasColumnType("datetime2");

                    b.Property<string>("deviceid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gstno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("logindate")
                        .HasColumnType("datetime2");

                    b.Property<string>("longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usertype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("whatappno")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("CoreMoryatools.Models.city", b =>
                {
                    b.HasOne("CoreMoryatools.Models.state", "state")
                        .WithMany()
                        .HasForeignKey("stateid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoreMoryatools.Models.product", b =>
                {
                    b.HasOne("CoreMoryatools.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("cid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoreMoryatools.Models.productimages", b =>
                {
                    b.HasOne("CoreMoryatools.Models.product", "product")
                        .WithMany()
                        .HasForeignKey("pid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoreMoryatools.Models.state", b =>
                {
                    b.HasOne("CoreMoryatools.Models.country", "country")
                        .WithMany()
                        .HasForeignKey("countryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
