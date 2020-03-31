using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "ctDivisa",
                schema: "public",
                columns: table => new
                {
                    llDivisa = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    dsDivisa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ctDivisa", x => x.llDivisa);
                });

            migrationBuilder.CreateTable(
                name: "ctTipoMovimiento",
                schema: "public",
                columns: table => new
                {
                    llTipoMovimiento = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    dsTipoMovimiento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ctTipoMovimiento", x => x.llTipoMovimiento);
                });

            migrationBuilder.CreateTable(
                name: "ctUsuario",
                schema: "public",
                columns: table => new
                {
                    llUsuario = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    dsNombre = table.Column<string>(nullable: true),
                    dsApellidoPaterno = table.Column<string>(nullable: true),
                    dsApellidoMaterno = table.Column<string>(nullable: true),
                    dsClaveUsuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ctUsuario", x => x.llUsuario);
                });

            migrationBuilder.CreateTable(
                name: "tbTurno",
                schema: "public",
                columns: table => new
                {
                    llTurno = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    llUsuario = table.Column<string>(nullable: true),
                    fcFechaApertura = table.Column<DateTime>(type: "date", nullable: false),
                    fcFechaHoraCierre = table.Column<DateTime>(type: "date", nullable: false),
                    dsFondoFijo = table.Column<decimal>(nullable: false),
                    dsFondoVenta = table.Column<decimal>(nullable: false),
                    dsTotalCierre = table.Column<decimal>(nullable: false),
                    EntregaCompleta = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTurno", x => x.llTurno);
                });

            migrationBuilder.CreateTable(
                name: "ctDenominacion",
                schema: "public",
                columns: table => new
                {
                    llDenominacion = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    llDivisa = table.Column<long>(nullable: false),
                    dsDenominacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ctDenominacion", x => x.llDenominacion);
                    table.ForeignKey(
                        name: "FK_ct_divisa_llDivisa",
                        column: x => x.llDivisa,
                        principalSchema: "public",
                        principalTable: "ctDivisa",
                        principalColumn: "llDivisa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbFondo",
                schema: "public",
                columns: table => new
                {
                    llFondo = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    llTurno = table.Column<long>(nullable: false),
                    llDenominacion = table.Column<long>(nullable: false),
                    llTipoMovimiento = table.Column<long>(nullable: false),
                    dsCantidad = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFondo", x => x.llFondo);
                    table.ForeignKey(
                        name: "FK_ct_denominacion_llDenominacion",
                        column: x => x.llDenominacion,
                        principalSchema: "public",
                        principalTable: "ctDenominacion",
                        principalColumn: "llDenominacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ct_tipo_movimiento_llTipoMovimiento",
                        column: x => x.llTipoMovimiento,
                        principalSchema: "public",
                        principalTable: "ctTipoMovimiento",
                        principalColumn: "llTipoMovimiento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_turno_llTurno",
                        column: x => x.llTurno,
                        principalSchema: "public",
                        principalTable: "tbTurno",
                        principalColumn: "llTurno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "ctDivisa",
                columns: new[] { "llDivisa", "dsDivisa" },
                values: new object[,]
                {
                    { 1L, "MXN" },
                    { 2L, "USD" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "ctTipoMovimiento",
                columns: new[] { "llTipoMovimiento", "dsTipoMovimiento" },
                values: new object[,]
                {
                    { 1L, "Apertura" },
                    { 2L, "Cierre" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "ctDenominacion",
                columns: new[] { "llDenominacion", "dsDenominacion", "llDivisa" },
                values: new object[,]
                {
                    { 1L, "Billete 50", 1L },
                    { 2L, "Dolar 100", 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ctDenominacion_llDivisa",
                schema: "public",
                table: "ctDenominacion",
                column: "llDivisa");

            migrationBuilder.CreateIndex(
                name: "IX_tbFondo_llDenominacion",
                schema: "public",
                table: "tbFondo",
                column: "llDenominacion");

            migrationBuilder.CreateIndex(
                name: "IX_tbFondo_llTipoMovimiento",
                schema: "public",
                table: "tbFondo",
                column: "llTipoMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_tbFondo_llTurno",
                schema: "public",
                table: "tbFondo",
                column: "llTurno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ctUsuario",
                schema: "public");

            migrationBuilder.DropTable(
                name: "tbFondo",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ctDenominacion",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ctTipoMovimiento",
                schema: "public");

            migrationBuilder.DropTable(
                name: "tbTurno",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ctDivisa",
                schema: "public");
        }
    }
}
