﻿// <auto-generated />
using BasicSalary.Entities.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BasicSalary.Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230823062725_Details")]
    partial class Details
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BasicSalary.Data.Model.EmployeeDetails", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BasicSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MobileNumber")
                        .HasMaxLength(10)
                        .HasColumnType("bigint");

                    b.HasKey("EmployeeId");

                    b.ToTable("employeeDetails");
                });

            modelBuilder.Entity("BasicSalary.Data.Model.SalaryGenerator", b =>
                {
                    b.Property<int>("SNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SNo"));

                    b.Property<decimal>("Allowance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeaveDays")
                        .HasColumnType("int");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PF")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WorkingDays")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("SNo");

                    b.ToTable("salaryGenerators");
                });
#pragma warning restore 612, 618
        }
    }
}