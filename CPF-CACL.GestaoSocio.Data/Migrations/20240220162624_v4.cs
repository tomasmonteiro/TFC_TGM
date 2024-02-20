using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPF_CACL.GestaoSocio.Data.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_TipoPagamento_TipoPagamentoId",
                table: "Pagamento");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Pagamento");

            migrationBuilder.AlterColumn<Guid>(
                name: "TipoPagamentoId",
                table: "Pagamento",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_TipoPagamento_TipoPagamentoId",
                table: "Pagamento",
                column: "TipoPagamentoId",
                principalTable: "TipoPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_TipoPagamento_TipoPagamentoId",
                table: "Pagamento");

            migrationBuilder.AlterColumn<Guid>(
                name: "TipoPagamentoId",
                table: "Pagamento",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Pagamento",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_TipoPagamento_TipoPagamentoId",
                table: "Pagamento",
                column: "TipoPagamentoId",
                principalTable: "TipoPagamento",
                principalColumn: "Id");
        }
    }
}
