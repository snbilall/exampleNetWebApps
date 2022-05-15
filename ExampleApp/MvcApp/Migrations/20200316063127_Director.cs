using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleApp.Migrations
{
    public partial class Director : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movie",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "Movie",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Movie",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Movie",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorId",
                table: "Movie",
                column: "DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Director_DirectorId",
                table: "Movie",
                column: "DirectorId",
                principalTable: "Director",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Director_DirectorId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropIndex(
                name: "IX_Movie_DirectorId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Movie");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movie",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "Movie",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Movie",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
