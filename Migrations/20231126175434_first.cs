using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Varejao.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hortifruti",
                columns: table => new
                {
                    IdHortifruti = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstoqueMinimo = table.Column<int>(type: "int", nullable: false),
                    EstoqueAtual = table.Column<int>(type: "int", nullable: false),
                    PrecoCusto = table.Column<float>(type: "real", nullable: false),
                    PrecoVenda = table.Column<float>(type: "real", nullable: false),
                    Icms = table.Column<float>(type: "real", nullable: false),
                    Iss = table.Column<float>(type: "real", nullable: false),
                    Cofins = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hortifruti", x => x.IdHortifruti);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    IdLote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantidadeHortifruti = table.Column<int>(type: "int", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdHortifruti = table.Column<int>(type: "int", nullable: false),
                    Fornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.IdLote);
                    table.ForeignKey(
                        name: "FK_Lote_Hortifruti_IdHortifruti",
                        column: x => x.IdHortifruti,
                        principalTable: "Hortifruti",
                        principalColumn: "IdHortifruti",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lote_IdHortifruti",
                table: "Lote",
                column: "IdHortifruti");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "Hortifruti");
        }
    }
}
