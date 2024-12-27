using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCNetwork.Migrations
{
    /// <inheritdoc />
    public partial class Device : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerDevices");

            migrationBuilder.AddColumn<string>(
                name: "DeviceId",
                table: "Players",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GameTag",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Players_DeviceId",
                table: "Players",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Devices_DeviceId",
                table: "Players",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Devices_DeviceId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_DeviceId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GameTag",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "PlayerDevices",
                columns: table => new
                {
                    PlayerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameTag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerDevices", x => new { x.PlayerId, x.DeviceId });
                    table.ForeignKey(
                        name: "FK_PlayerDevices_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerDevices_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDevices_DeviceId",
                table: "PlayerDevices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDevices_PlayerId",
                table: "PlayerDevices",
                column: "PlayerId",
                unique: true);
        }
    }
}
