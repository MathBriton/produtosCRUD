namespace produtoCRUD.Application.Handlers
{
    public class ProdutoCommandHandler
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoCommandHandler (IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoREpository;
        }

        // Atenção : Handler para criar produto
        public async Task Handle(CreateProdutoCommand command)
        {
            var produto = new Produto
            {
                Nome = command.Nome,
                Preco = command.Preco,
            };
            await _produtoRepository.AddAsync(produto);
        }

        // Atenção : Handler para atualizar produto.
        public async Task Handle (UpdateProdutoCommand command)
        {
            var produto = await _produtoReposity.GetByIdAsync(command.Id);
            if (produto != null)
            {
                produto.Nome = command.Nome;
                produto.Preco = command.Preco;
                await _produtoRepository.UpdateAsync(produto);
            }
        }

        // Atenção : Handler para excluir produto.
        public async Task Handle(DeleteProdutoCommand command)
        {
            await _produtoRepository.DeleteAsync(command.Id);
        }
    }
}
