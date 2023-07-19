using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TphGenericReferencesTph.Migrations
{
    /// <inheritdoc />
    public partial class redo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarBase_FooBases_FooExtensionId",
                table: "BarBase");

            migrationBuilder.DropIndex(
                name: "IX_BarBase_FooExtensionId",
                table: "BarBase");

            migrationBuilder.RenameColumn(
                name: "FooExtensionId",
                table: "BarBase",
                newName: "FooExtension<BarB>Id");

            migrationBuilder.AddColumn<int>(
                name: "FooExtension<BarA>Id",
                table: "BarBase",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_BarBase_FooBases_FooExtension<BarA>Id",
                table: "BarBase",
                column: "FooExtension<BarA>Id",
                principalTable: "FooBases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BarBase_FooBases_FooExtension<BarB>Id",
                table: "BarBase",
                column: "FooExtension<BarB>Id",
                principalTable: "FooBases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarBase_FooBases_FooExtension<BarA>Id",
                table: "BarBase");

            migrationBuilder.DropForeignKey(
                name: "FK_BarBase_FooBases_FooExtension<BarB>Id",
                table: "BarBase");

            migrationBuilder.DropIndex(
                name: "IX_BarBase_FooExtension<BarA>Id",
                table: "BarBase");

            migrationBuilder.DropIndex(
                name: "IX_BarBase_FooExtension<BarB>Id",
                table: "BarBase");

            migrationBuilder.DropColumn(
                name: "FooExtension<BarA>Id",
                table: "BarBase");

            migrationBuilder.RenameColumn(
                name: "FooExtension<BarB>Id",
                table: "BarBase",
                newName: "FooExtensionId");

            migrationBuilder.CreateIndex(
                name: "IX_BarBase_FooExtensionId",
                table: "BarBase",
                column: "FooExtensionId",
                unique: true,
                filter: "[FooExtension<BarA>Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BarBase_FooBases_FooExtensionId",
                table: "BarBase",
                column: "FooExtensionId",
                principalTable: "FooBases",
                principalColumn: "Id");
        }
    }
}
