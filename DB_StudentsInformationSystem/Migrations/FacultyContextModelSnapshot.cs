﻿// <auto-generated />
using System;
using DB_StudentsInformationSystem.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DB_StudentsInformationSystem.Migrations
{
    [DbContext(typeof(FacultyContext))]
    partial class FacultyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DB_StudentsInformationSystem.Database.Models.Faculty", b =>
                {
                    b.Property<int>("FacultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacultyId"));

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacultyId");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("DB_StudentsInformationSystem.Database.Models.FacultyLecture", b =>
                {
                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<int>("LectureId")
                        .HasColumnType("int");

                    b.HasKey("FacultyId", "LectureId");

                    b.HasIndex("LectureId");

                    b.ToTable("FacultyLectures");
                });

            modelBuilder.Entity("DB_StudentsInformationSystem.Database.Models.Lecture", b =>
                {
                    b.Property<int>("LectureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LectureId"));

                    b.Property<string>("LectureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LectureTimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LectureTimeStart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("LectureId");

                    b.HasIndex("StudentId");

                    b.ToTable("Lecture");
                });

            modelBuilder.Entity("DB_StudentsInformationSystem.Database.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("DB_StudentsInformationSystem.Database.Models.FacultyLecture", b =>
                {
                    b.HasOne("DB_StudentsInformationSystem.Database.Models.Faculty", "Faculty")
                        .WithMany("FacultyLectures")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB_StudentsInformationSystem.Database.Models.Lecture", "Lecture")
                        .WithMany("FacultyLectures")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("DB_StudentsInformationSystem.Database.Models.Lecture", b =>
                {
                    b.HasOne("DB_StudentsInformationSystem.Database.Models.Student", null)
                        .WithMany("Lectures")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("DB_StudentsInformationSystem.Database.Models.Student", b =>
                {
                    b.HasOne("DB_StudentsInformationSystem.Database.Models.Faculty", "Faculty")
                        .WithMany("Students")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("DB_StudentsInformationSystem.Database.Models.Faculty", b =>
                {
                    b.Navigation("FacultyLectures");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("DB_StudentsInformationSystem.Database.Models.Lecture", b =>
                {
                    b.Navigation("FacultyLectures");
                });

            modelBuilder.Entity("DB_StudentsInformationSystem.Database.Models.Student", b =>
                {
                    b.Navigation("Lectures");
                });
#pragma warning restore 612, 618
        }
    }
}
