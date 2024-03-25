using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPF_CACL.GestaoSocio.Data.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BairroId",
                table: "Fornecedor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_BairroId",
                table: "Fornecedor",
                column: "BairroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Bairro_BairroId",
                table: "Fornecedor",
                column: "BairroId",
                principalTable: "Bairro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Bairro_BairroId",
                table: "Fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedor_BairroId",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "BairroId",
                table: "Fornecedor");
        }
    }
}
