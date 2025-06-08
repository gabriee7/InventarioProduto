using InventarioProduto.Entities.Base;

namespace InventarioProduto.Entities
{
    public class ProdutoEntity : AuditableBaseEntity
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public int Quantidade { get; private set; }

        public ProdutoEntity(string nome, decimal preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public void SetNome(string nome) => Nome = nome;
        public void SetPreco(decimal preco) => Preco = preco;
        public void SetQuantidade(int quantidade) => Quantidade = quantidade;
    }
}
