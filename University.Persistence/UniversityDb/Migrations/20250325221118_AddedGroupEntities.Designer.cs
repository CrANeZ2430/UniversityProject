﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using University.Persistence.UniversityDb;

#nullable disable

namespace University.Persistence.UniversityDb.Migrations
{
    [DbContext(typeof(UniversityDbContext))]
    [Migration("20250325221118_AddedGroupEntities")]
    partial class AddedGroupEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("university")
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("University.Core.Domain.Departments.Models.Department", b =>
                {
                    b.Property<Guid>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnOrder(3);

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(4);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnOrder(2);

                    b.HasKey("DepartmentId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Departments", "university");
                });

            modelBuilder.Entity("University.Core.Domain.Faculties.Models.Faculty", b =>
                {
                    b.Property<Guid>("FacultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnOrder(3);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnOrder(2);

                    b.HasKey("FacultyId");

                    b.ToTable("Faculties", "university");
                });

            modelBuilder.Entity("University.Core.Domain.Groups.Models.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(4);

                    b.Property<int>("MaxStudents")
                        .HasColumnType("integer")
                        .HasColumnOrder(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnOrder(2);

                    b.HasKey("GroupId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Groups", "university");
                });

            modelBuilder.Entity("University.Core.Domain.Departments.Models.Department", b =>
                {
                    b.HasOne("University.Core.Domain.Faculties.Models.Faculty", "Faculty")
                        .WithMany("Departments")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("University.Core.Domain.Groups.Models.Group", b =>
                {
                    b.HasOne("University.Core.Domain.Departments.Models.Department", "Department")
                        .WithMany("Groups")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("University.Core.Domain.Departments.Models.Department", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("University.Core.Domain.Faculties.Models.Faculty", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
