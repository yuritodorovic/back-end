﻿// <auto-generated />
using System;
using BackEnd.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("BackEnd.Model.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("BackEnd.Model.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("BackEnd.Model.FornecedorEmpresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("FornededorEmpresas");
                });

            modelBuilder.Entity("BackEnd.Model.FornecedorEmpresa", b =>
                {
                    b.HasOne("BackEnd.Model.Empresa", "Empresa")
                        .WithMany("Fornecedores")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Model.Fornecedor", "Fornecedor")
                        .WithMany("Empresas")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("BackEnd.Model.Empresa", b =>
                {
                    b.Navigation("Fornecedores");
                });

            modelBuilder.Entity("BackEnd.Model.Fornecedor", b =>
                {
                    b.Navigation("Empresas");
                });
#pragma warning restore 612, 618
        }
    }
}
