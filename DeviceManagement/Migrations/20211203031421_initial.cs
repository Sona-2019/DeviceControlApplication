using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceManagement.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    deviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deviceStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deviceTemperature = table.Column<int>(type: "int", nullable: false),
                    deviceUsage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deviceThumbnail = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.deviceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device");
        }
    }
}
