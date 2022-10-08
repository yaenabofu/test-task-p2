﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Models.DatabaseObjects;

namespace api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221008123357_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api.Models.DatabaseObjects.Profession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Терапевт",
                            Name = "Терапевт"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Кардиолог",
                            Name = "Кардиолог"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Офтальмолог",
                            Name = "Офтальмолог"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Аллерголог",
                            Name = "Аллерголог"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Водитель автобуса",
                            Name = "Водитель автобуса"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Пилот самолета",
                            Name = "Пилот самолета"
                        });
                });

            modelBuilder.Entity("api.Models.DatabaseObjects.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProfessionId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfessionId1")
                        .HasColumnType("int");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkerId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessionId");

                    b.HasIndex("ProfessionId1");

                    b.HasIndex("WorkerId");

                    b.HasIndex("WorkerId1");

                    b.ToTable("Specialties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProfessionId = 1,
                            WorkerId = 1
                        },
                        new
                        {
                            Id = 2,
                            ProfessionId = 2,
                            WorkerId = 1
                        },
                        new
                        {
                            Id = 3,
                            ProfessionId = 3,
                            WorkerId = 2
                        },
                        new
                        {
                            Id = 4,
                            ProfessionId = 4,
                            WorkerId = 2
                        },
                        new
                        {
                            Id = 5,
                            ProfessionId = 5,
                            WorkerId = 3
                        },
                        new
                        {
                            Id = 6,
                            ProfessionId = 6,
                            WorkerId = 3
                        });
                });

            modelBuilder.Entity("api.Models.DatabaseObjects.WorkShift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkerId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.HasIndex("WorkerId1");

                    b.ToTable("WorkShifts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Смена 1",
                            EndDate = new DateTime(2022, 10, 8, 19, 33, 54, 747, DateTimeKind.Local).AddTicks(7689),
                            Name = "Смена 1",
                            StartDate = new DateTime(2022, 10, 8, 17, 33, 54, 747, DateTimeKind.Local).AddTicks(7359),
                            WorkerId = 2
                        },
                        new
                        {
                            Id = 2,
                            Description = "Смена 2",
                            EndDate = new DateTime(2022, 10, 8, 22, 33, 54, 748, DateTimeKind.Local).AddTicks(6138),
                            Name = "Смена 2",
                            StartDate = new DateTime(2022, 10, 8, 20, 33, 54, 748, DateTimeKind.Local).AddTicks(6099),
                            WorkerId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Смена 3",
                            EndDate = new DateTime(2022, 10, 8, 19, 33, 54, 748, DateTimeKind.Local).AddTicks(6163),
                            Name = "Смена 3",
                            StartDate = new DateTime(2022, 10, 8, 17, 33, 54, 748, DateTimeKind.Local).AddTicks(6161),
                            WorkerId = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "Смена 3",
                            EndDate = new DateTime(2022, 10, 8, 22, 33, 54, 748, DateTimeKind.Local).AddTicks(6167),
                            Name = "Смена 3",
                            StartDate = new DateTime(2022, 10, 8, 20, 33, 54, 748, DateTimeKind.Local).AddTicks(6165),
                            WorkerId = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "Смена 4",
                            EndDate = new DateTime(2022, 10, 8, 19, 33, 54, 748, DateTimeKind.Local).AddTicks(6172),
                            Name = "Смена 4",
                            StartDate = new DateTime(2022, 10, 8, 17, 33, 54, 748, DateTimeKind.Local).AddTicks(6171),
                            WorkerId = 2
                        },
                        new
                        {
                            Id = 6,
                            Description = "Смена 5",
                            EndDate = new DateTime(2022, 10, 8, 22, 33, 54, 748, DateTimeKind.Local).AddTicks(6175),
                            Name = "Смена 5",
                            StartDate = new DateTime(2022, 10, 8, 20, 33, 54, 748, DateTimeKind.Local).AddTicks(6174),
                            WorkerId = 3
                        });
                });

            modelBuilder.Entity("api.Models.DatabaseObjects.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Snils")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thirdname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(2022, 10, 8, 17, 33, 54, 746, DateTimeKind.Local).AddTicks(3355),
                            Name = "Иван",
                            Snils = "snils1",
                            Surname = "Иванов",
                            Thirdname = "Иванович"
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new DateTime(2022, 10, 8, 17, 33, 54, 747, DateTimeKind.Local).AddTicks(5672),
                            Name = "Name",
                            Snils = "snils1",
                            Surname = "Surname",
                            Thirdname = "Thirdname"
                        },
                        new
                        {
                            Id = 3,
                            Birthday = new DateTime(2022, 10, 8, 17, 33, 54, 747, DateTimeKind.Local).AddTicks(5703),
                            Name = "John",
                            Snils = "snils1",
                            Surname = "Doe",
                            Thirdname = "Bismark"
                        });
                });

            modelBuilder.Entity("api.Models.DatabaseObjects.Specialty", b =>
                {
                    b.HasOne("api.Models.DatabaseObjects.Profession", "Profession")
                        .WithMany()
                        .HasForeignKey("ProfessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.DatabaseObjects.Profession", null)
                        .WithMany("Specialties")
                        .HasForeignKey("ProfessionId1");

                    b.HasOne("api.Models.DatabaseObjects.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.DatabaseObjects.Worker", null)
                        .WithMany("Specialties")
                        .HasForeignKey("WorkerId1");

                    b.Navigation("Profession");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("api.Models.DatabaseObjects.WorkShift", b =>
                {
                    b.HasOne("api.Models.DatabaseObjects.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId");

                    b.HasOne("api.Models.DatabaseObjects.Worker", null)
                        .WithMany("WorkShifts")
                        .HasForeignKey("WorkerId1");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("api.Models.DatabaseObjects.Profession", b =>
                {
                    b.Navigation("Specialties");
                });

            modelBuilder.Entity("api.Models.DatabaseObjects.Worker", b =>
                {
                    b.Navigation("Specialties");

                    b.Navigation("WorkShifts");
                });
#pragma warning restore 612, 618
        }
    }
}