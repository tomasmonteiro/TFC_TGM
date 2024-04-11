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
                name: "FK_Saldo_Pagamento_PagamentoId",
                table: "Saldo");

            migrationBuilder.DropColumn(
                name: "DataPagamento",
                table: "Saldo");

            migrationBuilder.DropColumn(
                name: "Recibo",
                table: "Saldo");

            migrationBuilder.AlterColumn<string>(
                name: "CaminhoFoto",
                table: "Socio",
                type: "varchar(80)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PagamentoId",
                table: "Saldo",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Saldo_Pagamento_PagamentoId",
                table: "Saldo",
                column: "PagamentoId",
                principalTable: "Pagamento",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saldo_Pagamento_PagamentoId",
                table: "Saldo");

            migrationBuilder.AlterColumn<string>(
                name: "CaminhoFoto",
                table: "Socio",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PagamentoId",
                table: "Saldo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPagamento",
                table: "Saldo",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Recibo",
                table: "Saldo",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Saldo_Pagamento_PagamentoId",
                table: "Saldo",
                column: "PagamentoId",
                principalTable: "Pagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
