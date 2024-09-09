using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondBrain.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAccountId",
                table: "UserProfile",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_UserAccountId",
                table: "UserProfile",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_AspNetUsers_UserAccountId",
                table: "UserProfile",
                column: "UserAccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_AspNetUsers_UserAccountId",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_UserAccountId",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "UserProfile");
        }
    }
}
