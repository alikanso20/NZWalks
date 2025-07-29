using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingWalkdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[,]
                {
                    { new Guid("a1e1b2c3-d4e5-6789-0123-456789abcdef"), "A challenging day hike across volcanic terrain.", new Guid("d905c976-6303-45e4-b7ae-a2333549b092"), 19.399999999999999, "Tongariro Alpine Crossing", new Guid("1544305d-b597-49cb-829f-cf299f103b1b"), "https://example.com/tongariro.jpg" },
                    { new Guid("b2f2c3d4-e5f6-7890-1234-567890abcdef"), "A multi-day walk through Fiordland National Park.", new Guid("3b6f32c4-764c-4c19-841e-b4e475ab4a6e"), 53.5, "Milford Track", new Guid("26031ecb-2754-4431-852f-dce2729a45ec"), "https://example.com/milford.jpg" },
                    { new Guid("c3d4e5f6-7890-1234-5678-90abcdef1234"), "A scenic walk along Auckland's coastline.", new Guid("36e7f51c-f4cd-4869-9bb3-fa77b2c5f4f8"), 10.199999999999999, "Auckland Coast Walk", new Guid("495c11c8-1e70-4aa3-805f-2cd85c51050e"), "https://example.com/auckland-coast.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("a1e1b2c3-d4e5-6789-0123-456789abcdef"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b2f2c3d4-e5f6-7890-1234-567890abcdef"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-7890-1234-5678-90abcdef1234"));
        }
    }
}
