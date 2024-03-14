using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPF_CACL.GestaoSocio.Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Despesa",
                newName: "Valor");

            migrationBuilder.AddColumn<Guid>(
                name: "FornecedorId",
                table: "Despesa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_FornecedorId",
                table: "Despesa",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesa_Fornecedor_FornecedorId",
                table: "Despesa",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesa_Fornecedor_FornecedorId",
                table: "Despesa");

            migrationBuilder.DropIndex(
                name: "IX_Despesa_FornecedorId",
                table: "Despesa");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Despesa");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Despesa",
                newName: "Total");
        }
    }
}
