namespace produtoCRUD.Application.Command
{
    public class UpdateProdutoCommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

    }
}
