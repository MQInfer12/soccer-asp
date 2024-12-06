﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using asp_test.Data;

#nullable disable

namespace asptest.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20241206011636_TournamentGames")]
    partial class TournamentGames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("asp_test.Models.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Club1Id")
                        .HasColumnType("integer");

                    b.Property<int>("Club2Id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Club1Id");

                    b.HasIndex("Club2Id");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("asp_test.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Shield")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("asp_test.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Club1Id")
                        .HasColumnType("integer");

                    b.Property<int>("Club2Id")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("TournamentId")
                        .HasColumnType("integer");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Club1Id");

                    b.HasIndex("Club2Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("asp_test.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("asp_test.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Name")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("asp_test.Models.Banner", b =>
                {
                    b.HasOne("asp_test.Models.Club", "Club1")
                        .WithMany("Banners1")
                        .HasForeignKey("Club1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("asp_test.Models.Club", "Club2")
                        .WithMany("Banners2")
                        .HasForeignKey("Club2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club1");

                    b.Navigation("Club2");
                });

            modelBuilder.Entity("asp_test.Models.Game", b =>
                {
                    b.HasOne("asp_test.Models.Club", "Club1")
                        .WithMany("Games1")
                        .HasForeignKey("Club1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("asp_test.Models.Club", "Club2")
                        .WithMany("Games2")
                        .HasForeignKey("Club2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("asp_test.Models.Tournament", "Tournament")
                        .WithMany("Games")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club1");

                    b.Navigation("Club2");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("asp_test.Models.Club", b =>
                {
                    b.Navigation("Banners1");

                    b.Navigation("Banners2");

                    b.Navigation("Games1");

                    b.Navigation("Games2");
                });

            modelBuilder.Entity("asp_test.Models.Tournament", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
