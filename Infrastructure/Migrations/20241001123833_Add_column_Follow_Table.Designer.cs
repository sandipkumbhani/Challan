﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiLang;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241001123833_Add_column_Follow_Table")]
    partial class Add_column_Follow_Table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Model.DocumentViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BorrowerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BorrowersName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CitySurvey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CitySurveyNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityTalati")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("date");

                    b.Property<string>("DharaCenter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DharaCenterNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentPayment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EDharaCenter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GramPanchayat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellersName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Follow");
                });

            modelBuilder.Entity("Domain.Model.EmployeeViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("Domain.Model.QuotationViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("Amount_Dtl_Date")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("App_Date")
                        .HasColumnType("date");

                    b.Property<string>("App_mobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CircleOfficer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Con_Amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Con_Amount_Dtl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("Con_Date")
                        .HasColumnType("date");

                    b.Property<string>("Con_Refe_No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("Con_letter_Date")
                        .HasColumnType("date");

                    b.Property<string>("ConversionTax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LandArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mamlatdar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasurOrNot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("Measur_Date")
                        .HasColumnType("date");

                    b.Property<string>("Measur_Refe_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasurementNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Measurment_appli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opinion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Other")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("Pro_Date")
                        .HasColumnType("date");

                    b.Property<string>("Pro_Refe_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessFees")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurveyNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Taluka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Village")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lay_out")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("layout")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uncultivat_appli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quotation");
                });

            modelBuilder.Entity("Domain.Model.UserViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
