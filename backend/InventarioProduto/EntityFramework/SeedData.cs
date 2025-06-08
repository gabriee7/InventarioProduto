using InventarioProduto.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventarioProduto.EntityFramework
{
    public static class SeedData
    {
        private static readonly Guid _produtoAId = new Guid("E2A8C9F0-7D3B-4A1E-9C6A-08D7E5B4C3F2");
        private static readonly Guid _produtoBId = new Guid("B5D9E8C1-6A2F-4B0D-8A3E-1F9C8B7A6D5E");
        private static readonly Guid _produtoCId = new Guid("C9F0B7A2-5E1D-4C9A-B2D8-2A0E1C9F8B7D");

        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedProdutos(modelBuilder);
        }

        private static void SeedProdutos(ModelBuilder modelBuilder)
        {
            var seedCreationTime = new DateTime(2025, 4, 1, 12, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<ProdutoEntity>(entity =>
            {
                entity.HasData(
                    new
                    {
                        _id = _produtoAId,
                        _creationTime = seedCreationTime,
                        _LastModifiedTime = (DateTime?)null,
                        Nome = "Produto A",
                        Preco = 29.98m,
                        Quantidade = 10
                    },
                    new
                    {
                        _id = _produtoBId,
                        _creationTime = seedCreationTime,
                        _LastModifiedTime = (DateTime?)null,
                        Nome = "Produto B",
                        Preco = 59.98m,
                        Quantidade = 4
                    },
                    new
                    {
                        _id = _produtoCId,
                        _creationTime = seedCreationTime,
                        _LastModifiedTime = (DateTime?)null,
                        Nome = "Produto C",
                        Preco = 109.98m,
                        Quantidade = 2
                    }
                );
            });
        }
    }
}