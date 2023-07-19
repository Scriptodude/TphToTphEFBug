﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TphGenericReferencesTph.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230719205013_base")]
    partial class @base
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BarBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BarBase");

                    b.HasDiscriminator<string>("type").HasValue("BarBase");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FooBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FooBases");

                    b.HasDiscriminator<string>("type").HasValue("FooBase");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BarA", b =>
                {
                    b.HasBaseType("BarBase");

                    b.Property<string>("A")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FooExtensionId")
                        .HasColumnType("int");

                    b.HasIndex("FooExtensionId")
                        .IsUnique()
                        .HasFilter("[FooExtension<BarA>Id] IS NOT NULL");

                    b.HasDiscriminator().HasValue("BarA");
                });

            modelBuilder.Entity("BarB", b =>
                {
                    b.HasBaseType("BarBase");

                    b.Property<bool>("B")
                        .HasColumnType("bit");

                    b.Property<int?>("FooExtensionId")
                        .HasColumnType("int");

                    b.HasIndex("FooExtensionId")
                        .IsUnique()
                        .HasFilter("[FooExtension<BarB>Id] IS NOT NULL");

                    b.HasDiscriminator().HasValue("BarB");
                });

            modelBuilder.Entity(".FooExtension<BarA>", b =>
                {
                    b.HasBaseType("FooBase");

                    b.HasDiscriminator().HasValue("BarAFooExtension");
                });

            modelBuilder.Entity(".FooExtension<BarB>", b =>
                {
                    b.HasBaseType("FooBase");

                    b.HasDiscriminator().HasValue("BarBFooExtension");
                });

            modelBuilder.Entity("BarA", b =>
                {
                    b.HasOne(".FooExtension<BarA>", null)
                        .WithOne("Bar")
                        .HasForeignKey("BarA", "FooExtensionId");
                });

            modelBuilder.Entity("BarB", b =>
                {
                    b.HasOne(".FooExtension<BarB>", null)
                        .WithOne("Bar")
                        .HasForeignKey("BarB", "FooExtensionId");
                });

            modelBuilder.Entity(".FooExtension<BarA>", b =>
                {
                    b.Navigation("Bar");
                });

            modelBuilder.Entity(".FooExtension<BarB>", b =>
                {
                    b.Navigation("Bar");
                });
#pragma warning restore 612, 618
        }
    }
}
