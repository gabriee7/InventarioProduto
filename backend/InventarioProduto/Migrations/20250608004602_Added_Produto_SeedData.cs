using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventarioProduto.Migrations
{
    /// <inheritdoc />
    public partial class Added_Produto_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Nome", "Preco", "Quantidade", "LastModifiedTime", "CreationTime" },
                values: new object[,]
                {
                    { new Guid("b5d9e8c1-6a2f-4b0d-8a3e-1f9c8b7a6d5e"), "Produto B", 59.98m, 4, null, new DateTime(2025, 4, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c9f0b7a2-5e1d-4c9a-b2d8-2a0e1c9f8b7d"), "Produto C", 109.98m, 2, null, new DateTime(2025, 4, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("e2a8c9f0-7d3b-4a1e-9c6a-08d7e5b4c3f2"), "Produto A", 29.98m, 10, null, new DateTime(2025, 4, 1, 12, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("b5d9e8c1-6a2f-4b0d-8a3e-1f9c8b7a6d5e"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("c9f0b7a2-5e1d-4c9a-b2d8-2a0e1c9f8b7d"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("e2a8c9f0-7d3b-4a1e-9c6a-08d7e5b4c3f2"));
        }
    }
}
