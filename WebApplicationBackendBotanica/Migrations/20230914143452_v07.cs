using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplicationBackendBotanica.Migrations
{
    /// <inheritdoc />
    public partial class v07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artigo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artigo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artigo_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Encomenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DataEncomenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: true),
                    ArtigoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encomenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encomenda_Artigo_ArtigoId",
                        column: x => x.ArtigoId,
                        principalTable: "Artigo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Encomenda_Utilizador_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizador",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Plantas" },
                    { 2, "Solo" }
                });

            migrationBuilder.InsertData(
                table: "Utilizador",
                columns: new[] { "Id", "Morada", "Nome", "Pass", "UserName" },
                values: new object[,]
                {
                    { 1, " Rua 11", "ze Pintas", "a", "zepin" },
                    { 2, " Rua 12", "Maria Calas Pintas", "a", "macalas" },
                    { 3, " Rua 31", "Jose oliveira", "a", "zeo" },
                    { 4, " Rua 14", "jonana souzas", "a", "jasou" }
                });

            migrationBuilder.InsertData(
                table: "Artigo",
                columns: new[] { "Id", "CategoriaId", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, 1, "Orquidias", 0.5 },
                    { 2, 1, "Margaridas", 2.5 },
                    { 3, 2, "Terra do Bosque", 2.5 },
                    { 4, 2, "Terra do campo", 3.5 }
                });

            migrationBuilder.InsertData(
                table: "Encomenda",
                columns: new[] { "Id", "ArtigoId", "DataEncomenda", "Quantidade", "UtilizadorId" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2023, 9, 14, 15, 34, 52, 191, DateTimeKind.Local).AddTicks(6405), 50, 1 },
                    { 2, 1, new DateTime(2023, 9, 14, 15, 34, 52, 191, DateTimeKind.Local).AddTicks(6450), 40, 1 },
                    { 3, 2, new DateTime(2023, 9, 14, 15, 34, 52, 191, DateTimeKind.Local).AddTicks(6453), 50, 3 },
                    { 4, 3, new DateTime(2023, 9, 14, 15, 34, 52, 191, DateTimeKind.Local).AddTicks(6456), 30, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artigo_CategoriaId",
                table: "Artigo",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Encomenda_ArtigoId",
                table: "Encomenda",
                column: "ArtigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Encomenda_UtilizadorId",
                table: "Encomenda",
                column: "UtilizadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Encomenda");

            migrationBuilder.DropTable(
                name: "Artigo");

            migrationBuilder.DropTable(
                name: "Utilizador");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
