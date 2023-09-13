using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationBackendBotanica.Migrations
{
    /// <inheritdoc />
    public partial class dbapp5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 13, 15, 55, 55, 474, DateTimeKind.Local).AddTicks(5344));

            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 13, 15, 55, 55, 474, DateTimeKind.Local).AddTicks(5389));

            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 13, 15, 55, 55, 474, DateTimeKind.Local).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 13, 15, 55, 55, 474, DateTimeKind.Local).AddTicks(5394));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 13, 13, 3, 58, 310, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 13, 13, 3, 58, 310, DateTimeKind.Local).AddTicks(3024));

            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 13, 13, 3, 58, 310, DateTimeKind.Local).AddTicks(3026));

            migrationBuilder.UpdateData(
                table: "Encomenda",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataEncomenda",
                value: new DateTime(2023, 9, 13, 13, 3, 58, 310, DateTimeKind.Local).AddTicks(3029));
        }
    }
}
