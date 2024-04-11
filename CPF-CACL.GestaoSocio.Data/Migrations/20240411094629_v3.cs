using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPF_CACL.GestaoSocio.Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlAnexo",
                table: "SolicitacaoApoio",
                type: "varchar(70)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlAnexo",
                table: "SolicitacaoApoio",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(70)",
                oldNullable: true);
        }
    }
}
