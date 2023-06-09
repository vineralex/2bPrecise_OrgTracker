﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrgTracker.API.DbContexts;

#nullable disable

namespace OrgTracker.API.Migrations
{
    [DbContext(typeof(OrgTrackerDbContext))]
    partial class OrgTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrgTracker.API.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OrgTracker.API.Entities.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReportingEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("SupervisingManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReportingEmployeeId");

                    b.HasIndex("SupervisingManagerId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("OrgTracker.API.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AssignedToId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SupervisingManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("SupervisingManagerId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("OrgTracker.API.Entities.Employee", b =>
                {
                    b.HasOne("OrgTracker.API.Entities.Employee", "Manager")
                        .WithMany("Subordinates")
                        .HasForeignKey("ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("OrgTracker.API.Entities.Report", b =>
                {
                    b.HasOne("OrgTracker.API.Entities.Employee", "ReportingEmployee")
                        .WithMany()
                        .HasForeignKey("ReportingEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrgTracker.API.Entities.Employee", "SupervisingManager")
                        .WithMany("Reports")
                        .HasForeignKey("SupervisingManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportingEmployee");

                    b.Navigation("SupervisingManager");
                });

            modelBuilder.Entity("OrgTracker.API.Entities.Task", b =>
                {
                    b.HasOne("OrgTracker.API.Entities.Employee", "AssignedTo")
                        .WithMany("Tasks")
                        .HasForeignKey("AssignedToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrgTracker.API.Entities.Employee", "SupervisingManager")
                        .WithMany()
                        .HasForeignKey("SupervisingManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedTo");

                    b.Navigation("SupervisingManager");
                });

            modelBuilder.Entity("OrgTracker.API.Entities.Employee", b =>
                {
                    b.Navigation("Reports");

                    b.Navigation("Subordinates");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
