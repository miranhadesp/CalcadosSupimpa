using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Loja_Sapatos.Migrations
{
    public partial class add_values : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "Endereco", "Nome" },
                values: new object[] { 1, "00000000000000", "Rua Victor Augusto, 230", "Victor Augusto" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Id", "CodigoRef", "Cor", "Id_fornecedor", "Nome", "Tamanho" },
                values: new object[] { 1, "a321", "Rosa", 2, "Sapatênis", 34 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
