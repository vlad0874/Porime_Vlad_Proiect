using Microsoft.EntityFrameworkCore.Migrations;

namespace Vlad_Porime_Proiect.Migrations
{
    public partial class ShoeCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FactoryID",
                table: "Shoe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Factory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShoeCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoeCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeCategory_Shoe_ShoeID",
                        column: x => x.ShoeID,
                        principalTable: "Shoe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_FactoryID",
                table: "Shoe",
                column: "FactoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeCategory_CategoryID",
                table: "ShoeCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeCategory_ShoeID",
                table: "ShoeCategory",
                column: "ShoeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoe_Factory_FactoryID",
                table: "Shoe",
                column: "FactoryID",
                principalTable: "Factory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoe_Factory_FactoryID",
                table: "Shoe");

            migrationBuilder.DropTable(
                name: "Factory");

            migrationBuilder.DropTable(
                name: "ShoeCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Shoe_FactoryID",
                table: "Shoe");

            migrationBuilder.DropColumn(
                name: "FactoryID",
                table: "Shoe");
        }
    }
}
