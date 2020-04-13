using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab23v2.Migrations
{
    public partial class FirstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDesc = table.Column<string>(maxLength: 100, nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Items__727E83EB3AE374E3", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(maxLength: 30, nullable: false),
                    LName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 75, nullable: false),
                    Pass = table.Column<string>(maxLength: 30, nullable: false),
                    Wallet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CCAC26301223", x => x.UserID);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "ItemDesc", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Anodized Aluminum Case", 88, 4 },
                    { 2, "60% Printed Circut Board (PCB)", 45, 1 },
                    { 3, "75% Printed Circuit Board (PCB)", 53, 3 },
                    { 4, "Tactile Mechanical Switches", 4, 300 },
                    { 5, "Linear Mechanical Switches", 4, 0 },
                    { 6, "Clicky Mechanical Switches", 4, 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
