﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestProyecto.Context;

namespace TestProyecto.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230727204316_TestBiblioteca2")]
    partial class TestBiblioteca2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TestProyecto.Entities.Cliente", b =>
                {
                    b.Property<int>("PkCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApellidoCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CorreoCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("FkRol")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("SaldoCliente")
                        .HasColumnType("double");

                    b.HasKey("PkCliente");

                    b.HasIndex("FkRol");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("TestProyecto.Entities.Lote", b =>
                {
                    b.Property<int>("PkLote")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("NomLote")
                        .HasColumnType("int");

                    b.HasKey("PkLote");

                    b.ToTable("Lotes");
                });

            modelBuilder.Entity("TestProyecto.Entities.Producto", b =>
                {
                    b.Property<int>("PkProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("FkLote")
                        .HasColumnType("int");

                    b.Property<int?>("FkSabor")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("FkTamaño")
                        .HasColumnType("int");

                    b.Property<int?>("FkVendedor")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("PrecioUnitario")
                        .HasColumnType("double");

                    b.HasKey("PkProducto");

                    b.HasIndex("FkLote");

                    b.HasIndex("FkSabor");

                    b.HasIndex("FkTamaño");

                    b.HasIndex("FkVendedor");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("TestProyecto.Entities.Rol", b =>
                {
                    b.Property<int>("PkRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RolName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TestProyecto.Entities.Sabor", b =>
                {
                    b.Property<int>("PkSabor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NameSabor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkSabor");

                    b.ToTable("Sabores");
                });

            modelBuilder.Entity("TestProyecto.Entities.SuperAdmin", b =>
                {
                    b.Property<int>("PkSuperAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApellidoSuperAdmin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContraseñaSuperAdmin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CorreoSuperAdmin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("NombreSuperAdmin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkSuperAdmin");

                    b.HasIndex("FkRol");

                    b.ToTable("SuperAdministradores");
                });

            modelBuilder.Entity("TestProyecto.Entities.Tamaño", b =>
                {
                    b.Property<int>("PkTamaño")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TamañoP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkTamaño");

                    b.ToTable("Tamaños");
                });

            modelBuilder.Entity("TestProyecto.Entities.Vendedor", b =>
                {
                    b.Property<int>("PkVendedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApellidoVendedor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContraseñaVendedor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CorreoV")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("NombreVendedor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkVendedor");

                    b.HasIndex("FkRol");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("TestProyecto.Entities.Venta", b =>
                {
                    b.Property<int>("PkCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime");

                    b.Property<int?>("FkCliente")
                        .HasColumnType("int");

                    b.Property<int?>("FkVendedor")
                        .HasColumnType("int");

                    b.HasKey("PkCompra");

                    b.HasIndex("FkCliente");

                    b.HasIndex("FkVendedor");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("TestProyecto.Entities.Cliente", b =>
                {
                    b.HasOne("TestProyecto.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("TestProyecto.Entities.Producto", b =>
                {
                    b.HasOne("TestProyecto.Entities.Lote", "Lotes")
                        .WithMany()
                        .HasForeignKey("FkLote");

                    b.HasOne("TestProyecto.Entities.Sabor", "Sabores")
                        .WithMany()
                        .HasForeignKey("FkSabor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestProyecto.Entities.Tamaño", "Tamaños")
                        .WithMany()
                        .HasForeignKey("FkTamaño")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestProyecto.Entities.Vendedor", "Vendedores")
                        .WithMany()
                        .HasForeignKey("FkVendedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lotes");

                    b.Navigation("Sabores");

                    b.Navigation("Tamaños");

                    b.Navigation("Vendedores");
                });

            modelBuilder.Entity("TestProyecto.Entities.SuperAdmin", b =>
                {
                    b.HasOne("TestProyecto.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("TestProyecto.Entities.Vendedor", b =>
                {
                    b.HasOne("TestProyecto.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("TestProyecto.Entities.Venta", b =>
                {
                    b.HasOne("TestProyecto.Entities.Cliente", "Clientes")
                        .WithMany()
                        .HasForeignKey("FkCliente");

                    b.HasOne("TestProyecto.Entities.Vendedor", "Vendedores")
                        .WithMany()
                        .HasForeignKey("FkVendedor");

                    b.Navigation("Clientes");

                    b.Navigation("Vendedores");
                });
#pragma warning restore 612, 618
        }
    }
}
