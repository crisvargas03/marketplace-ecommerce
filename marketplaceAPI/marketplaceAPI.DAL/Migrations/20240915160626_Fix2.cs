using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace marketplaceAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2024, 9, 15, 12, 6, 25, 899, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2024, 9, 15, 12, 6, 25, 899, DateTimeKind.Local).AddTicks(845));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreationDate",
                value: new DateTime(2024, 9, 15, 12, 6, 25, 899, DateTimeKind.Local).AddTicks(847));

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2024, 9, 15, 12, 6, 25, 900, DateTimeKind.Local).AddTicks(6817));

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate" },
                values: new object[] { 2002, "Dataseed", new DateTime(2024, 9, 15, 12, 6, 25, 900, DateTimeKind.Local).AddTicks(6828), null, "Sent", false, null, null });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteDate", "IsDeleted", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { 200, "Dataseed", new DateTime(2024, 9, 15, 12, 6, 25, 903, DateTimeKind.Local).AddTicks(6453), null, false, null, null, "Client" },
                    { 900, "Dataseed", new DateTime(2024, 9, 15, 12, 6, 25, 903, DateTimeKind.Local).AddTicks(6445), null, false, null, null, "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 2002);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 900);

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

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2024, 9, 15, 11, 59, 44, 957, DateTimeKind.Local).AddTicks(4251));

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate" },
                values: new object[] { 1002, "Dataseed", new DateTime(2024, 9, 15, 11, 59, 44, 957, DateTimeKind.Local).AddTicks(4258), null, "Sent", false, null, null });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteDate", "IsDeleted", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { 3003, "Dataseed", new DateTime(2024, 9, 15, 11, 59, 44, 958, DateTimeKind.Local).AddTicks(2812), null, false, null, null, "Admin" },
                    { 4004, "Dataeed", new DateTime(2024, 9, 15, 11, 59, 44, 958, DateTimeKind.Local).AddTicks(2820), null, false, null, null, "Client" }
                });
        }
    }
}
