using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApi.Migrations
{
    /// <inheritdoc />
    public partial class UserModelCityEntityRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityEntities_UserEntities_UserEntityId",
                table: "CityEntities");

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "CityEntities",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CityEntities_UserEntityId",
                table: "CityEntities",
                newName: "IX_CityEntities_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CityEntities_UserEntities_UserId",
                table: "CityEntities",
                column: "UserId",
                principalTable: "UserEntities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityEntities_UserEntities_UserId",
                table: "CityEntities");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CityEntities",
                newName: "UserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_CityEntities_UserId",
                table: "CityEntities",
                newName: "IX_CityEntities_UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CityEntities_UserEntities_UserEntityId",
                table: "CityEntities",
                column: "UserEntityId",
                principalTable: "UserEntities",
                principalColumn: "Id");
        }
    }
}
