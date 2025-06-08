using InventarioProduto.Services.Pagination;
using InventarioProduto.Services.Produto.Dtos;

namespace InventarioProduto.Services.Produto
{
    public interface IProdutoService
    {
        Task<ProdutoDto> Create(CreateProdutoDto input);
        Task<ProdutoDto> GetById(string id);
        Task<PagedResultDto<ProdutoDto>> GetAll(PagedRequestDto input);
        Task<ProdutoDto> Update(UpdateProdutoDto input);
        Task Delete(string id);
    }
}
