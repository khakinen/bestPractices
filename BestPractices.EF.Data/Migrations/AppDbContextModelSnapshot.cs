﻿// <auto-generated />
using System;
using BestPractices.EF.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BestPractices.EF.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("BestPractices.EF.Data.Repositories.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentRank")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b5303b5b-2be8-4c65-bb43-92b0bafdd006"),
                            Name = "Bob",
                            StudentRank = 1
                        },
                        new
                        {
                            Id = new Guid("a002720c-8828-46b4-ba61-1d633c2610eb"),
                            Name = "Alice",
                            StudentRank = 2
                        },
                        new
                        {
                            Id = new Guid("e5494a6c-3d81-4e8e-948e-286c36f16e92"),
                            Name = "Jack",
                            StudentRank = 3
                        });
                });

            modelBuilder.Entity("BestPractices.EF.Data.Repositories.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherRank")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e98287b2-4f0b-4aad-a907-0f86615016ca"),
                            Name = "MrBob",
                            TeacherRank = 1
                        },
                        new
                        {
                            Id = new Guid("677a15d9-ce06-43a1-8e29-ac273b130e34"),
                            Name = "MrsAlice",
                            TeacherRank = 2
                        },
                        new
                        {
                            Id = new Guid("cb3456a7-e71f-4b33-b3ef-8f68f0d77753"),
                            Name = "MrJack",
                            TeacherRank = 3
                        });
                });

            modelBuilder.Entity("BestPractices.EF.Data.Repositories.Student", b =>
                {
                    b.HasOne("BestPractices.EF.Data.Repositories.Teacher", null)
                        .WithMany("Students")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("BestPractices.EF.Data.Repositories.Teacher", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
