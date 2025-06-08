using InventarioProduto.EntityFramework;
using InventarioProduto.Entities;
using InventarioProduto.Services.Pagination;
using InventarioProduto.Services.Produto.Dtos;
using Microsoft.EntityFrameworkCore;

namespace InventarioProduto.Services.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly InventarioProdutoDbContext _context;

        public ProdutoService(InventarioProdutoDbContext context)
        {
            _context = context;
        }

        public async Task<ProdutoDto> Create(CreateProdutoDto input)
        {
            var entity = new ProdutoEntity(
                input.Nome,
                input.Preco,
                input.Quantidade
            );

            _context.Produtos.Add(entity);
            await _context.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task<ProdutoDto> Update(UpdateProdutoDto input)
        {
            var id = input.Id;

            var entity = await _context.Produtos.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Produto não encontrado.");

            entity.SetNome(input.Nome);
            entity.SetPreco(input.Preco);
            entity.SetQuantidade(input.Quantidade);
            entity.SetModifiedTime();

            await _context.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task Delete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                throw new ArgumentException("Id inválido.");

            var entity = await _context.Produtos.FindAsync(guid);
            if (entity == null) throw new KeyNotFoundException("Produto não encontrado.");

            _context.Produtos.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ProdutoDto> GetById(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                throw new ArgumentException("Id inválido.");

            var entity = await _context.Produtos.FindAsync(guid);
            if (entity == null) throw new KeyNotFoundException("Produto não encontrado.");

            return MapToDto(entity);
        }

        public async Task<PagedResultDto<ProdutoDto>> GetAll(PagedRequestDto input)
        {
            var query = _context.Produtos.AsQueryable();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(p => p.Nome)
                .Skip((input.PageNumber - 1) * input.PageSize)
                .Take(input.PageSize)
                .ToListAsync();

            var dtoList = items.Select(MapToDto).ToList();

            return new PagedResultDto<ProdutoDto>(
                dtoList,
                totalCount,
                input.PageNumber,
                input.PageSize
            );
        }

        private ProdutoDto MapToDto(ProdutoEntity entity)
        {
            var dto = new ProdutoDto()
            {
                Id = entity.GetGuid(),
                Nome = entity.Nome,
                Preco = entity.Preco,
                Quantidade = entity.Quantidade,
                CreationTime = entity.GetCreationTime(),
                LastModifiedTime = entity.GetLastModifiedTime()
            };
            return dto;
        }
    }
}
