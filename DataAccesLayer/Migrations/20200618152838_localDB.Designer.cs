﻿// <auto-generated />
using System;
using DataAccesLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccesLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200618152838_localDB")]
    partial class localDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataAccesLayer.EntityFramework.EFRoster", b =>
                {
                    b.Property<int>("RosterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RosterId");

                    b.HasIndex("ShiftId");

                    b.HasIndex("UserId");

                    b.ToTable("Rosters");
                });

            modelBuilder.Entity("DataAccesLayer.EntityFramework.EFShift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ShiftId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("DataAccesLayer.EntityFramework.EFTrade", b =>
                {
                    b.Property<int>("TradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AcceptUserId")
                        .HasColumnType("int");

                    b.Property<int>("RequestUserId")
                        .HasColumnType("int");

                    b.Property<int>("ReworkShiftId")
                        .HasColumnType("int");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.HasKey("TradeId");

                    b.HasIndex("AcceptUserId");

                    b.HasIndex("RequestUserId");

                    b.HasIndex("ReworkShiftId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("DataAccesLayer.EntityFramework.EFUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataAccesLayer.EntityFramework.EFRoster", b =>
                {
                    b.HasOne("DataAccesLayer.EntityFramework.EFShift", "Shift")
                        .WithMany("Rosters")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccesLayer.EntityFramework.EFUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccesLayer.EntityFramework.EFTrade", b =>
                {
                    b.HasOne("DataAccesLayer.EntityFramework.EFUser", "AcceptUser")
                        .WithMany()
                        .HasForeignKey("AcceptUserId");

                    b.HasOne("DataAccesLayer.EntityFramework.EFUser", "RequestUser")
                        .WithMany()
                        .HasForeignKey("RequestUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccesLayer.EntityFramework.EFShift", "ReworkShift")
                        .WithMany()
                        .HasForeignKey("ReworkShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccesLayer.EntityFramework.EFShift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
