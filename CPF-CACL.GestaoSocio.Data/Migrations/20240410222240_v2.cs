using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPF_CACL.GestaoSocio.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoApoio_EstadoSolicitacao_EstadoSolicitacaoId",
                table: "SolicitacaoApoio");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoDeclaracao_EstadoSolicitacao_EstadoSolicitacaoId",
                table: "SolicitacaoDeclaracao");

            migrationBuilder.DropTable(
                name: "EstadoSolicitacao");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoDeclaracao_EstadoSolicitacaoId",
                table: "SolicitacaoDeclaracao");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoApoio_EstadoSolicitacaoId",
                table: "SolicitacaoApoio");

            migrationBuilder.DropColumn(
                name: "EstadoSolicitacaoId",
                table: "SolicitacaoDeclaracao");

            migrationBuilder.DropColumn(
                name: "EstadoSolicitacaoId",
                table: "SolicitacaoApoio");

            migrationBuilder.AddColumn<string>(
                name: "EstadoSolicitacao",
                table: "SolicitacaoDeclaracao",
                type: "varchar(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EstadoSolicitacao",
                table: "SolicitacaoApoio",
                type: "varchar(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagamento",
                table: "Pagamento",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoSolicitacao",
                table: "SolicitacaoDeclaracao");

            migrationBuilder.DropColumn(
                name: "EstadoSolicitacao",
                table: "SolicitacaoApoio");

            migrationBuilder.AddColumn<Guid>(
                name: "EstadoSolicitacaoId",
                table: "SolicitacaoDeclaracao",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EstadoSolicitacaoId",
                table: "SolicitacaoApoio",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagamento",
                table: "Pagamento",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "EstadoSolicitacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Estado = table.Column<string>(type: "varchar(10)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoSolicitacao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoDeclaracao_EstadoSolicitacaoId",
                table: "SolicitacaoDeclaracao",
                column: "EstadoSolicitacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoApoio_EstadoSolicitacaoId",
                table: "SolicitacaoApoio",
                column: "EstadoSolicitacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoApoio_EstadoSolicitacao_EstadoSolicitacaoId",
                table: "SolicitacaoApoio",
                column: "EstadoSolicitacaoId",
                principalTable: "EstadoSolicitacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoDeclaracao_EstadoSolicitacao_EstadoSolicitacaoId",
                table: "SolicitacaoDeclaracao",
                column: "EstadoSolicitacaoId",
                principalTable: "EstadoSolicitacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
