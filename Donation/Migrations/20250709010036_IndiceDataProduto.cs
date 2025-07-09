using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Donation.Migrations
{
    /// <inheritdoc />
    public partial class IndiceDataProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Produto_DataCadastro",
                table: "Produto",
                column: "DataCadastro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Produto_DataCadastro",
                table: "Produto");
        }
    }
}
