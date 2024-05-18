﻿// <auto-generated />
using System;
using E_Project_Pharmacy.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Project_Pharmacy.Migrations
{
    [DbContext(typeof(database))]
    partial class databaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("E_Project_Pharmacy.Models.About", b =>
                {
                    b.Property<int>("about_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("about_id"), 1L, 1);

                    b.Property<string>("about_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("about_img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("about_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cheak_one")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cheak_three")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cheak_two")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("about_id");

                    b.ToTable("About");
                });

            modelBuilder.Entity("E_Project_Pharmacy.Models.Carrer", b =>
                {
                    b.Property<int>("carrer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("carrer_id"), 1L, 1);

                    b.Property<string>("carrer_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("carrer_location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("carrer_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("carrer_id");

                    b.ToTable("Carrer");
                });

            modelBuilder.Entity("E_Project_Pharmacy.Models.categare", b =>
                {
                    b.Property<int>("c_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("c_id"), 1L, 1);

                    b.Property<string>("c_img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("c_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("c_id");

                    b.ToTable("categare");
                });

            modelBuilder.Entity("E_Project_Pharmacy.Models.Contact", b =>
                {
                    b.Property<int>("contact_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("contact_id"), 1L, 1);

                    b.Property<string>("contact_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("contact_id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("E_Project_Pharmacy.Models.Doctor", b =>
                {
                    b.Property<int>("doctor_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("doctor_id"), 1L, 1);

                    b.Property<string>("doctor_img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doctor_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doctor_position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("doctor_id");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("E_Project_Pharmacy.Models.Quote", b =>
                {
                    b.Property<int>("Quote_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Quote_id"), 1L, 1);

                    b.Property<string>("Quote_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quote_country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quote_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quote_message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quote_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quote_phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quote_post")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Quote_id");

                    b.ToTable("Quote");
                });

            modelBuilder.Entity("E_Project_Pharmacy.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("E_Project_Pharmacy.Models.Sub_Categare", b =>
                {
                    b.Property<int>("sub_c_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sub_c_id"), 1L, 1);

                    b.Property<int>("cat_id")
                        .HasColumnType("int");

                    b.Property<string>("sub_c_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sub_c_img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sub_c_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sub_c_price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("sub_c_id");

                    b.ToTable("Sub_Categare");
                });

            modelBuilder.Entity("E_Project_Pharmacy.Models.user_resume", b =>
                {
                    b.Property<int>("r_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("r_id"), 1L, 1);

                    b.Property<int>("c_id")
                        .HasColumnType("int");

                    b.Property<string>("r_country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("r_edu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("r_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("r_location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("r_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("r_phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("r_resume")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.HasKey("r_id");

                    b.ToTable("user_resume");
                });

            modelBuilder.Entity("E_Project_Pharmacy.Models.Users", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_id"), 1L, 1);

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("user_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("E_Project_Pharmacy.Models.Why_Choose", b =>
                {
                    b.Property<int>("w_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("w_id"), 1L, 1);

                    b.Property<string>("w_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("w_img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("w_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("w_id");

                    b.ToTable("Why_choose");
                });
#pragma warning restore 612, 618
        }
    }
}
