using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3b6f32c4-764c-4c19-841e-b4e475ab4a6e"),
                column: "Name",
                value: "Medium");

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d905c976-6303-45e4-b7ae-a2333549b092"),
                column: "Name",
                value: "Hard");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1544305d-b597-49cb-829f-cf299f103b1b"),
                columns: new[] { "Code", "Name", "RegionImageUrl" },
                values: new object[] { "NI", "North Island", "https://example.com/north-island.jpg" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5b164fea-7e3b-43bd-9582-000d580d5184"),
                columns: new[] { "Code", "Name", "RegionImageUrl" },
                values: new object[] { "WK", "Waikato", "https://example.com/waikato.jpg" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8006eb7f-ba5a-444d-888c-8436c1ce13d0"),
                columns: new[] { "Code", "Name", "RegionImageUrl" },
                values: new object[] { "BP", "Bay of Plenty", "https://example.com/bay-of-plenty.jpg" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8053d0ef-a054-4b87-bd16-bd76da7ba654"),
                columns: new[] { "Code", "Name", "RegionImageUrl" },
                values: new object[] { "MW", "Manawatu-Whanganui", "https://example.com/manawatu-whanganui.jpg" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fed10ff2-47f5-4a6f-b3fb-ed14e3dc655c"),
                columns: new[] { "Code", "Name", "RegionImageUrl" },
                values: new object[] { "CA", "Canterbury", "https://example.com/canterbury.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3b6f32c4-764c-4c19-841e-b4e475ab4a6e"),
                column: "Name",
                value: "Hard");

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d905c976-6303-45e4-b7ae-a2333549b092"),
                column: "Name",
                value: "Medium");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1544305d-b597-49cb-829f-cf299f103b1b"),
                columns: new[] { "Code", "Name", "RegionImageUrl" },
                values: new object[] { "MW", "Manawatu-Whanganui", "https://example.com/manawatu-whanganui.jpg" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5b164fea-7e3b-43bd-9582-000d580d5184"),
                columns: new[] { "Code", "Name", "RegionImageUrl" },
                values: new object[] { "CA", "Canterbury", "https://example.com/canterbury.jpg" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8006eb7f-ba5a-444d-888c-8436c1ce13d0"),
                columns: new[] { "Code", "Name", "RegionImageUrl" },
                values: new object[] { "NI", "North Island", "https://example.com/north-island.jpg" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8053d0ef-a054-4b87-bd16-bd76da7ba654"),
                columns: new[] { "Code", "Name", "RegionImageUrl" },
                values: new object[] { "BP", "Bay of Plenty", "https://example.com/bay-of-plenty.jpg" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fed10ff2-47f5-4a6f-b3fb-ed14e3dc655c"),
                columns: new[] { "Code", "Name", "RegionImageUrl" },
                values: new object[] { "WK", "Waikato", "https://example.com/waikato.jpg" });
        }
    }
}
