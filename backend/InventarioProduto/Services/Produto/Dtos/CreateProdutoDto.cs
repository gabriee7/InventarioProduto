using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventarioProduto.Services.Produto.Dtos
{
    public class CreateProdutoDto
    {
        [JsonPropertyName("nome")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [JsonPropertyName("preco")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [JsonPropertyName("quantidade")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
        public int Quantidade { get; set; }
    }
}
