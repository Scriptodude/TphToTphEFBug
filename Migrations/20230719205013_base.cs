using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TphGenericReferencesTph.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FooBases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooBases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BarBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    A = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooExtensionBarAId = table.Column<int>(name: "FooExtension<BarA>Id", type: "int", nullable: true),
                    B = table.Column<bool>(type: "bit", nullable: true),
                    FooExtensionBarBId = table.Column<int>(name: "FooExtension<BarB>Id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarBase_FooBases_FooExtension<BarA>Id",
                        column: x => x.FooExtensionBarAId,
                        principalTable: "FooBases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BarBase_FooBases_FooExtension<BarB>Id",
                        column: x => x.FooExtensionBarBId,
                        principalTable: "FooBases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarBase_FooExtension<BarA>Id",
                table: "BarBase",
                column: "FooExtension<BarA>Id",
                unique: true,
                filter: "[FooExtension<BarA>Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BarBase_FooExtension<BarB>Id",
                table: "BarBase",
                column: "FooExtension<BarB>Id",
                unique: true,
                filter: "[FooExtension<BarB>Id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarBase");

            migrationBuilder.DropTable(
                name: "FooBases");
        }
    }
}
