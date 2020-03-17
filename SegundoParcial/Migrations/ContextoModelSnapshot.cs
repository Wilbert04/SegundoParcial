﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SegundoParcial.DAL;

namespace SegundoParcial.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("SegundoParcial.Entidades.Llamada", b =>
                {
                    b.Property<int>("LlamadaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.HasKey("LlamadaId");

                    b.ToTable("llamadaTable1");
                });

            modelBuilder.Entity("SegundoParcial.Entidades.LlamadaDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LLamadaid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Problema")
                        .HasColumnType("TEXT");

                    b.Property<string>("Solucion")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LLamadaid");

                    b.ToTable("LlamadaDetalle");
                });

            modelBuilder.Entity("SegundoParcial.Entidades.LlamadaDetalle", b =>
                {
                    b.HasOne("SegundoParcial.Entidades.Llamada", null)
                        .WithMany("Detalles")
                        .HasForeignKey("LLamadaid");
                });
#pragma warning restore 612, 618
        }
    }
}