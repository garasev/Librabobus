﻿// <auto-generated />
using System;
using Librabobus.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Librabobus.Backend.Migrations
{
    [DbContext(typeof(LibrabobusDbContext))]
    partial class LibrabobusDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Librabobus")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Librabobus.Database.Models.Record", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KeyWords")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("SubjectId");

                    b.ToTable("Record");
                });

            modelBuilder.Entity("Librabobus.Database.Models.SavedSubject", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "SubjectId");

                    b.HasIndex("SubjectId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("SavedSubject");
                });

            modelBuilder.Entity("Librabobus.Database.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("PhotoBase64")
                        .HasColumnType("text");

                    b.Property<bool>("Privat")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("Librabobus.Database.Models.Subscription", b =>
                {
                    b.Property<Guid>("UserFromId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserToId")
                        .HasColumnType("uuid");

                    b.HasKey("UserFromId", "UserToId");

                    b.HasIndex("UserFromId")
                        .IsUnique();

                    b.HasIndex("UserToId")
                        .IsUnique();

                    b.ToTable("Subscription");
                });

            modelBuilder.Entity("Librabobus.Database.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("About")
                        .HasColumnType("text");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoBase64")
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Librabobus.Database.Models.Record", b =>
                {
                    b.HasOne("Librabobus.Database.Models.Subject", "Subject")
                        .WithMany("Records")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Librabobus.Database.Models.SavedSubject", b =>
                {
                    b.HasOne("Librabobus.Database.Models.Subject", "Subject")
                        .WithMany("SavedSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Librabobus.Database.Models.User", "User")
                        .WithMany("SavedSubjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Librabobus.Database.Models.Subject", b =>
                {
                    b.HasOne("Librabobus.Database.Models.User", "Owner")
                        .WithMany("Subjects")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Librabobus.Database.Models.Subscription", b =>
                {
                    b.HasOne("Librabobus.Database.Models.User", "UserFrom")
                        .WithMany("Subscriptions")
                        .HasForeignKey("UserFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Librabobus.Database.Models.User", "UserTo")
                        .WithMany("Subscribers")
                        .HasForeignKey("UserToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserFrom");

                    b.Navigation("UserTo");
                });

            modelBuilder.Entity("Librabobus.Database.Models.Subject", b =>
                {
                    b.Navigation("Records");

                    b.Navigation("SavedSubjects");
                });

            modelBuilder.Entity("Librabobus.Database.Models.User", b =>
                {
                    b.Navigation("SavedSubjects");

                    b.Navigation("Subjects");

                    b.Navigation("Subscribers");

                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
