﻿// <auto-generated />
using System;
using Application.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Application.Migrations
{
    [DbContext(typeof(NonStopContext))]
    [Migration("20190608154608_RequestStatus")]
    partial class RequestStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Application.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DocumentTypeId");

                    b.Property<byte[]>("Image");

                    b.Property<int?>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("PersonId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Application.Models.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DocumentType");
                });

            modelBuilder.Entity("Application.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<int>("UnivercityId");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Application.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Name");

                    b.Property<string>("PatronymicName");

                    b.Property<string>("Surname");

                    b.Property<int?>("UnivercityId");

                    b.HasKey("Id");

                    b.HasIndex("UnivercityId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Application.Models.PointsBySubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfPoints");

                    b.Property<int?>("PersonId");

                    b.Property<int?>("SubjectId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("SubjectId");

                    b.ToTable("PointsBySubjects");
                });

            modelBuilder.Entity("Application.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<int?>("PersonId");

                    b.Property<int?>("SpecializationId");

                    b.Property<int>("Status");

                    b.Property<int?>("UnivercityId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("SpecializationId");

                    b.HasIndex("UnivercityId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Application.Models.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<int?>("UnivercityId");

                    b.HasKey("Id");

                    b.HasAlternateKey("Code");

                    b.HasIndex("UnivercityId");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("Application.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("ScoreThreshold");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Application.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("SpecializationId");

                    b.HasKey("Id");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Application.Models.Univercity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Univercities");
                });

            modelBuilder.Entity("Application.Models.UnivercitySpecialization", b =>
                {
                    b.Property<int>("UnivercityId");

                    b.Property<int>("SpecializationId");

                    b.HasKey("UnivercityId", "SpecializationId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("UnivercitySpecialization");
                });

            modelBuilder.Entity("Application.Models.Document", b =>
                {
                    b.HasOne("Application.Models.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId");

                    b.HasOne("Application.Models.Person", "Person")
                        .WithMany("Documents")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Application.Models.Person", b =>
                {
                    b.HasOne("Application.Models.Univercity", "Univercity")
                        .WithMany()
                        .HasForeignKey("UnivercityId");
                });

            modelBuilder.Entity("Application.Models.PointsBySubject", b =>
                {
                    b.HasOne("Application.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("Application.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("Application.Models.Request", b =>
                {
                    b.HasOne("Application.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("Application.Models.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId");

                    b.HasOne("Application.Models.Univercity", "Univercity")
                        .WithMany()
                        .HasForeignKey("UnivercityId");
                });

            modelBuilder.Entity("Application.Models.Specialization", b =>
                {
                    b.HasOne("Application.Models.Univercity")
                        .WithMany("Specializations")
                        .HasForeignKey("UnivercityId");
                });

            modelBuilder.Entity("Application.Models.Tag", b =>
                {
                    b.HasOne("Application.Models.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId");
                });

            modelBuilder.Entity("Application.Models.UnivercitySpecialization", b =>
                {
                    b.HasOne("Application.Models.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Application.Models.Univercity", "Univercity")
                        .WithMany()
                        .HasForeignKey("UnivercityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
