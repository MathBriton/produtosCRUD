namespace produtoCRUD.Domain.Interfaces
{
    public class IProdutoRepository
    {
        Task<Produto>GetByIdAsync(int id);
        Task<List<Produto> GetAllAsync();
        Task AddSync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(int id);
    }
}
