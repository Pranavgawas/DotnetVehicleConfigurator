﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vehicle.Models;

#nullable disable

namespace demo1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230829052955_vehicle")]
    partial class vehicle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("demo1.Models.Alternate_Component", b =>
                {
                    b.Property<int>("alt_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("alt_comp_id")
                        .HasColumnType("int");

                    b.Property<int>("comp_id")
                        .HasColumnType("int");

                    b.Property<double>("delta_price")
                        .HasColumnType("double");

                    b.Property<int>("model_id")
                        .HasColumnType("int");

                    b.HasKey("alt_id");

                    b.ToTable("alternet_component");
                });

            modelBuilder.Entity("demo1.Models.Component", b =>
                {
                    b.Property<int>("comp_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("comp_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("sub_type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("comp_id");

                    b.ToTable("Component");
                });

            modelBuilder.Entity("demo1.Models.Manufacturer", b =>
                {
                    b.Property<int>("Mfg_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Mfg_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Seg_id")
                        .HasColumnType("int");

                    b.HasKey("Mfg_id");

                    b.HasIndex("Seg_id");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("demo1.Models.Segment", b =>
                {
                    b.Property<int>("Seg_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<string>("Seg_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Seg_id");

                    b.ToTable("Segment");
                });

            modelBuilder.Entity("demo1.Models.Variant", b =>
                {
                    b.Property<int>("Model_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Mfg_id")
                        .HasColumnType("int");

                    b.Property<string>("Model_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("Seg_id")
                        .HasColumnType("int");

                    b.HasKey("Model_id");

                    b.HasIndex("Mfg_id");

                    b.HasIndex("Seg_id");

                    b.ToTable("Variant");
                });

            modelBuilder.Entity("demo1.Models.Vehicle_detail", b =>
                {
                    b.Property<int>("config_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("comp_id")
                        .HasColumnType("int");

                    b.Property<string>("comp_type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("id_configurable")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("model_id")
                        .HasColumnType("int");

                    b.HasKey("config_id");

                    b.HasIndex("comp_id");

                    b.HasIndex("model_id");

                    b.ToTable("Vehicle_detail");
                });

            modelBuilder.Entity("demo1.Models.Manufacturer", b =>
                {
                    b.HasOne("demo1.Models.Segment", "segment")
                        .WithMany("Manufacturers")
                        .HasForeignKey("Seg_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("segment");
                });

            modelBuilder.Entity("demo1.Models.Variant", b =>
                {
                    b.HasOne("demo1.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("Mfg_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("demo1.Models.Segment", "Segment")
                        .WithMany("Variants")
                        .HasForeignKey("Seg_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");

                    b.Navigation("Segment");
                });

            modelBuilder.Entity("demo1.Models.Vehicle_detail", b =>
                {
                    b.HasOne("demo1.Models.Component", "component")
                        .WithMany("Vehicle_Details")
                        .HasForeignKey("comp_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("demo1.Models.Variant", "variant")
                        .WithMany()
                        .HasForeignKey("model_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("component");

                    b.Navigation("variant");
                });

            modelBuilder.Entity("demo1.Models.Component", b =>
                {
                    b.Navigation("Vehicle_Details");
                });

            modelBuilder.Entity("demo1.Models.Segment", b =>
                {
                    b.Navigation("Manufacturers");

                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
