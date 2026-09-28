namespace ProdutosCodeFirst.Models
{
    public class Produto
    {
        public Guid? Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Marca { get; set; } = string.Empty;

        public decimal Preco { get; set; }

        public int QtdeEstoque { get; set; }

        public bool Ativo { get; set; }
    }
}
