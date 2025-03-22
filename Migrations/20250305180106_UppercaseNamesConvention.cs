using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AulaEntity.Migrations
{
    /// <inheritdoc />
    public partial class UppercaseNamesConvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudantes",
                table: "Estudantes");

            migrationBuilder.RenameTable(
                name: "Estudantes",
                newName: "ESTUDANTES");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "ESTUDANTES",
                newName: "NOME");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "ESTUDANTES",
                newName: "ATIVO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ESTUDANTES",
                newName: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESTUDANTES",
                table: "ESTUDANTES",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ESTUDANTES",
                table: "ESTUDANTES");

            migrationBuilder.RenameTable(
                name: "ESTUDANTES",
                newName: "Estudantes");

            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "Estudantes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "ATIVO",
                table: "Estudantes",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Estudantes",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudantes",
                table: "Estudantes",
                column: "Id");
        }
    }
}
