using InventarioProduto.Services.Pagination;

namespace InventarioProduto.Services.Produto.Dtos
{
    public class PagedProdutoDto : PagedResultDto<ProdutoDto>
    {
        public PagedProdutoDto(
            IReadOnlyList<ProdutoDto> items,
            int totalCount,
            int pageNumber,
            int pageSize)
            : base(items, totalCount, pageNumber, pageSize)
        {
        }
    }
}
