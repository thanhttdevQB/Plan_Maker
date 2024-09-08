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
            migrationBuilder.RenameColumn(
                name: "Percentage",
                table: "BigTasks",
                newName: "PercentageDone");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BigTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "BigTasks");

            migrationBuilder.RenameColumn(
                name: "PercentageDone",
                table: "BigTasks",
                newName: "Percentage");
        }
    }
}
