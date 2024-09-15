using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace marketplaceAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Fixtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "UserRole",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2024, 9, 15, 11, 59, 44, 956, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2024, 9, 15, 11, 59, 44, 956, DateTimeKind.Local).AddTicks(6801));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreationDate",
                value: new DateTime(2024, 9, 15, 11, 59, 44, 956, DateTimeKind.Local).AddTicks(6803));

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate" },
                values: new object[,]
                {
                    { 1001, "Dataseed", new DateTime(2024, 9, 15, 11, 59, 44, 957, DateTimeKind.Local).AddTicks(4251), null, "Open", false, null, null },
                    { 1002, "Dataseed", new DateTime(2024, 9, 15, 11, 59, 44, 957, DateTimeKind.Local).AddTicks(4258), null, "Sent", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteDate", "IsDeleted", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { 3003, "Dataseed", new DateTime(2024, 9, 15, 11, 59, 44, 958, DateTimeKind.Local).AddTicks(2812), null, false, null, null, "Admin" },
                    { 4004, "Dataeed", new DateTime(2024, 9, 15, 11, 59, 44, 958, DateTimeKind.Local).AddTicks(2820), null, false, null, null, "Client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 3003);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 4004);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "UserRole",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 13, 2, 583, DateTimeKind.Local).AddTicks(19));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 13, 2, 583, DateTimeKind.Local).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreationDate",
                value: new DateTime(2024, 9, 11, 12, 13, 2, 583, DateTimeKind.Local).AddTicks(37));
        }
    }
}
