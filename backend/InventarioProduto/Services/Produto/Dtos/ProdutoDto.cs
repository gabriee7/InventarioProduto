using System.Text.Json.Serialization;

namespace InventarioProduto.Services.Produto.Dtos
{
    public class ProdutoDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("preco")]
        public decimal Preco { get; set; }

        [JsonPropertyName("quantidade")]
        public int Quantidade { get; set; }

        [JsonPropertyName("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonPropertyName("lastModifiedTime")]
        public DateTime? LastModifiedTime { get; set; }
    }
}
