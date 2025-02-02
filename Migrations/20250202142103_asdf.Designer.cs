﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication5.Model;

#nullable disable

namespace WebApplication5.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250202142103_asdf")]
    partial class asdf
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication5.Model.ClassRoom", b =>
                {
                    b.Property<int>("ClassRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassRoomId"));

                    b.Property<string>("ClassRoomChapter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ClassRoomClassDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("ClassRoomClassTime")
                        .HasColumnType("time");

                    b.Property<string>("ClassRoomDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassRoomSubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassRoomVideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassRoomId");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("WebApplication5.Model.Cources", b =>
                {
                    b.Property<int>("CourcesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourcesId"));

                    b.Property<string>("CourcesDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourcesTiltle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourcesUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Courcesimageurl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourcesId");

                    b.ToTable("Courches");
                });

            modelBuilder.Entity("WebApplication5.Model.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("SubjectId");

                    b.HasIndex("TaskId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("WebApplication5.Model.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TaskDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("WebApplication5.Model.Subject", b =>
                {
                    b.HasOne("WebApplication5.Model.Task", "Task")
                        .WithMany("Subject")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("WebApplication5.Model.Task", b =>
                {
                    b.HasOne("WebApplication5.Model.ClassRoom", "ClassRoom")
                        .WithMany("Tasks")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassRoom");
                });

            modelBuilder.Entity("WebApplication5.Model.ClassRoom", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("WebApplication5.Model.Task", b =>
                {
                    b.Navigation("Subject");
                });
#pragma warning restore 612, 618
        }
    }
}
