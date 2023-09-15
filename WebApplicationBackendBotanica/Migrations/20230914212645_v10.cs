using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationBackendBotanica.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 14, 22, 26, 45, 458, DateTimeKind.Local).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 14, 22, 26, 45, 458, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 14, 22, 26, 45, 458, DateTimeKind.Local).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 14, 22, 26, 45, 458, DateTimeKind.Local).AddTicks(2423));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 14, 16, 14, 14, 697, DateTimeKind.Local).AddTicks(2723));

            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 14, 16, 14, 14, 697, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 14, 16, 14, 14, 697, DateTimeKind.Local).AddTicks(2767));

            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 14, 16, 14, 14, 697, DateTimeKind.Local).AddTicks(2770));
        }
    }
}
