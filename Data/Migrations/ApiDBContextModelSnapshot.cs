﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    [DbContext(typeof(ApiDBContext))]
    partial class ApiDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Data.CtDenominacion", b =>
                {
                    b.Property<long>("PKIdDenominacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("llDenominacion");

                    b.Property<string>("Descripcion")
                        .HasColumnName("dsDenominacion");

                    b.Property<long>("FKIdDivisa")
                        .HasColumnName("llDivisa");

                    b.HasKey("PKIdDenominacion");

                    b.HasIndex("FKIdDivisa");

                    b.ToTable("ctDenominacion");

                    b.HasData(
                        new
                        {
                            PKIdDenominacion = 1L,
                            Descripcion = "Billete 50",
                            FKIdDivisa = 1L
                        },
                        new
                        {
                            PKIdDenominacion = 2L,
                            Descripcion = "Dolar 100",
                            FKIdDivisa = 2L
                        });
                });

            modelBuilder.Entity("Data.CtDivisa", b =>
                {
                    b.Property<long>("PkIdDivisa")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("llDivisa");

                    b.Property<string>("Divisa")
                        .HasColumnName("dsDivisa");

                    b.HasKey("PkIdDivisa");

                    b.ToTable("ctDivisa");

                    b.HasData(
                        new
                        {
                            PkIdDivisa = 1L,
                            Divisa = "MXN"
                        },
                        new
                        {
                            PkIdDivisa = 2L,
                            Divisa = "USD"
                        });
                });

            modelBuilder.Entity("Data.CtTipoMovimiento", b =>
                {
                    b.Property<long>("PKIdTipoMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("llTipoMovimiento");

                    b.Property<string>("TipoMovimiento")
                        .HasColumnName("dsTipoMovimiento");

                    b.HasKey("PKIdTipoMovimiento");

                    b.ToTable("ctTipoMovimiento");

                    b.HasData(
                        new
                        {
                            PKIdTipoMovimiento = 1L,
                            TipoMovimiento = "Apertura"
                        },
                        new
                        {
                            PKIdTipoMovimiento = 2L,
                            TipoMovimiento = "Cierre"
                        });
                });

            modelBuilder.Entity("Data.CtUsuario", b =>
                {
                    b.Property<long>("PKIdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("llUsuario");

                    b.Property<string>("ApellidoMaterno")
                        .HasColumnName("dsApellidoMaterno");

                    b.Property<string>("ApellidoPaterno")
                        .HasColumnName("dsApellidoPaterno");

                    b.Property<string>("ClaveUsuario")
                        .HasColumnName("dsClaveUsuario");

                    b.Property<string>("Nombre")
                        .HasColumnName("dsNombre");

                    b.HasKey("PKIdUsuario");

                    b.ToTable("ctUsuario");
                });

            modelBuilder.Entity("Data.TbFondo", b =>
                {
                    b.Property<long>("PKIdFondo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("llFondo");

                    b.Property<long>("Cantidad")
                        .HasColumnName("dsCantidad");

                    b.Property<long>("FKIdDenominacion")
                        .HasColumnName("llDenominacion");

                    b.Property<long>("FKIdTipoMovimiento")
                        .HasColumnName("llTipoMovimiento");

                    b.Property<long>("FKIdTurno")
                        .HasColumnName("llTurno");

                    b.HasKey("PKIdFondo");

                    b.HasIndex("FKIdDenominacion");

                    b.HasIndex("FKIdTipoMovimiento");

                    b.HasIndex("FKIdTurno");

                    b.ToTable("tbFondo");
                });

            modelBuilder.Entity("Data.TbTurno", b =>
                {
                    b.Property<long>("PKIdTurno")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("llTurno");

                    b.Property<bool>("EntregaCompleta")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<DateTime>("FechaHoraApertura")
                        .HasColumnName("fcFechaApertura")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaHoraCierre")
                        .HasColumnName("fcFechaHoraCierre")
                        .HasColumnType("date");

                    b.Property<decimal>("FondoFijo")
                        .HasColumnName("dsFondoFijo");

                    b.Property<decimal>("FondoVenta")
                        .HasColumnName("dsFondoVenta");

                    b.Property<string>("IdUsuario")
                        .HasColumnName("llUsuario");

                    b.Property<decimal>("TotalCierre")
                        .HasColumnName("dsTotalCierre");

                    b.HasKey("PKIdTurno");

                    b.ToTable("tbTurno");
                });

            modelBuilder.Entity("Data.CtDenominacion", b =>
                {
                    b.HasOne("Data.CtDivisa", "FkIdDivisaNavigation")
                        .WithMany("CtDenominacion")
                        .HasForeignKey("FKIdDivisa")
                        .HasConstraintName("FK_ct_divisa_llDivisa")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.TbFondo", b =>
                {
                    b.HasOne("Data.CtDenominacion", "FKIdDenominacionNavigation")
                        .WithMany("TbFondo")
                        .HasForeignKey("FKIdDenominacion")
                        .HasConstraintName("FK_ct_denominacion_llDenominacion")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.CtTipoMovimiento", "FKIdTipoMovimientoNavigation")
                        .WithMany("TbFondo")
                        .HasForeignKey("FKIdTipoMovimiento")
                        .HasConstraintName("FK_ct_tipo_movimiento_llTipoMovimiento")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.TbTurno", "FKIdTurnoNavigation")
                        .WithMany("TbFondo")
                        .HasForeignKey("FKIdTurno")
                        .HasConstraintName("FK_tb_turno_llTurno")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
