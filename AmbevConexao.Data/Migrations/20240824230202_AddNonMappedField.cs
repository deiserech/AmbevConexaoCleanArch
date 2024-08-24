using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmbevConexao.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNonMappedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoStatus",
                table: "Matricula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescricaoStatus",
                table: "Matricula",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
