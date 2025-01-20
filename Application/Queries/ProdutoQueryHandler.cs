using produtoCRUD.Domain.Entities;
using produtoCRUD.Domain.Interfaces;
using produtoCRUD.Application.Queries;

namespace produtoCRUD.Application.Queries
{
    public class ProdutoQueryHandler
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoQueryHandler (IProdutoRepository produtoRepository)
        {
            _produtoReposistory = produtoRepository;
        }

        public async Task <List<Produto>> Handle(GetAllProdutosQuery query)
        {
            return await _produtoRepository.GetAllAsync();
        }
    }
}
