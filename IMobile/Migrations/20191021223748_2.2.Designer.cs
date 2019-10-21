﻿// <auto-generated />
using IMobile.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IMobile.Migrations
{
    [DbContext(typeof(IMobileContext))]
    [Migration("20191021223748_2.2")]
    partial class _22
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IMobile.Models.Accessorie", b =>
                {
                    b.Property<int>("AccessorieID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Manufacture");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.Property<int>("SupplierID");

                    b.HasKey("AccessorieID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Accessorie");
                });

            modelBuilder.Entity("IMobile.Models.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserID");

                    b.HasKey("CartID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("IMobile.Models.CartItemAcc", b =>
                {
                    b.Property<int>("CartItemAccID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessorieID");

                    b.Property<int>("CartID");

                    b.Property<int>("Quantity");

                    b.HasKey("CartItemAccID");

                    b.HasIndex("AccessorieID");

                    b.HasIndex("CartID");

                    b.ToTable("CartItemAcc");
                });

            modelBuilder.Entity("IMobile.Models.CartItemDevice", b =>
                {
                    b.Property<int>("CartItemDeviceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartID");

                    b.Property<int>("DeviceID");

                    b.Property<int>("Quantity");

                    b.HasKey("CartItemDeviceID");

                    b.HasIndex("CartID");

                    b.HasIndex("DeviceID");

                    b.ToTable("CartItemDevice");
                });

            modelBuilder.Entity("IMobile.Models.Device", b =>
                {
                    b.Property<int>("DeviceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Manufacture")
                        .IsRequired();

                    b.Property<int>("Memory");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.Property<int>("RamMemory");

                    b.Property<float>("ScreenSize");

                    b.Property<int>("SupplierID");

                    b.Property<int>("ViewCounter");

                    b.HasKey("DeviceID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("IMobile.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("SupplierID");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("IMobile.Models.Accessorie", b =>
                {
                    b.HasOne("IMobile.Models.Supplier", "Supplier")
                        .WithMany("AccList")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IMobile.Models.CartItemAcc", b =>
                {
                    b.HasOne("IMobile.Models.Accessorie", "Accessorie")
                        .WithMany("CartItemAcc")
                        .HasForeignKey("AccessorieID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IMobile.Models.Cart", "Cart")
                        .WithMany("AccList")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IMobile.Models.CartItemDevice", b =>
                {
                    b.HasOne("IMobile.Models.Cart", "Cart")
                        .WithMany("DeviceList")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IMobile.Models.Device", "Device")
                        .WithMany("CartItemDevice")
                        .HasForeignKey("DeviceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IMobile.Models.Device", b =>
                {
                    b.HasOne("IMobile.Models.Supplier", "Supplier")
                        .WithMany("DeviceList")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
