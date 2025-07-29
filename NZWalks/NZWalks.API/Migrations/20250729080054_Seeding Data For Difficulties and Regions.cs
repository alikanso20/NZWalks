using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("36e7f51c-f4cd-4869-9bb3-fa77b2c5f4f8"), "Easy" },
                    { new Guid("3b6f32c4-764c-4c19-841e-b4e475ab4a6e"), "Hard" },
                    { new Guid("d905c976-6303-45e4-b7ae-a2333549b092"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1544305d-b597-49cb-829f-cf299f103b1b"), "MW", "Manawatu-Whanganui", "https://example.com/manawatu-whanganui.jpg" },
                    { new Guid("26031ecb-2754-4431-852f-dce2729a45ec"), "SI", "South Island", "https://example.com/south-island.jpg" },
                    { new Guid("495c11c8-1e70-4aa3-805f-2cd85c51050e"), "AU", "Auckland", "https://example.com/auckland.jpg" },
                    { new Guid("5b164fea-7e3b-43bd-9582-000d580d5184"), "CA", "Canterbury", "https://example.com/canterbury.jpg" },
                    { new Guid("8006eb7f-ba5a-444d-888c-8436c1ce13d0"), "NI", "North Island", "https://example.com/north-island.jpg" },
                    { new Guid("8053d0ef-a054-4b87-bd16-bd76da7ba654"), "BP", "Bay of Plenty", "https://example.com/bay-of-plenty.jpg" },
                    { new Guid("fed10ff2-47f5-4a6f-b3fb-ed14e3dc655c"), "WK", "Waikato", "https://example.com/waikato.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("36e7f51c-f4cd-4869-9bb3-fa77b2c5f4f8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3b6f32c4-764c-4c19-841e-b4e475ab4a6e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d905c976-6303-45e4-b7ae-a2333549b092"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1544305d-b597-49cb-829f-cf299f103b1b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("26031ecb-2754-4431-852f-dce2729a45ec"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("495c11c8-1e70-4aa3-805f-2cd85c51050e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5b164fea-7e3b-43bd-9582-000d580d5184"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8006eb7f-ba5a-444d-888c-8436c1ce13d0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8053d0ef-a054-4b87-bd16-bd76da7ba654"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fed10ff2-47f5-4a6f-b3fb-ed14e3dc655c"));
        }
    }
}
