using Microsoft.EntityFrameworkCore.Migrations;

namespace AgroVision.Dal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCalculation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    Hectares = table.Column<double>(nullable: false),
                    MinimimSprayRate = table.Column<double>(nullable: false),
                    LitersPerHectare = table.Column<double>(nullable: false),
                    AgentAmount = table.Column<double>(nullable: false),
                    WaterAmount = table.Column<double>(nullable: false),
                    CropType = table.Column<string>(nullable: true),
                    SprayingAgent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCalculation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCalculation_UserId",
                table: "UserCalculation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCalculation");
        }
    }
}
