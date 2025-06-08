using Microsoft.EntityFrameworkCore;
using InventarioProduto.Entities;

namespace InventarioProduto.EntityFramework
{
    public class InventarioProdutoDbContext : DbContext
    {
        public InventarioProdutoDbContext(DbContextOptions<InventarioProdutoDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProdutoEntity> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProdutoEntity>(entity =>
            {
                entity.ToTable("Produtos");

                entity.Property<Guid>("_id")
                      .HasColumnName("Id")
                      .ValueGeneratedNever();

                entity.HasKey("_id");

                entity.Property<DateTime>("_creationTime")
                      .HasColumnName("CreationTime")
                      .IsRequired();

                entity.Property<DateTime?>("_LastModifiedTime")
                      .HasColumnName("LastModifiedTime");

                entity.Property(p => p.Nome)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.Preco)
                      .IsRequired();

                entity.Property(p => p.Quantidade)
                      .IsRequired();
            });

            SeedData.Seed(modelBuilder);
        }
    }
}
