namespace VendasPadaria.Models
{
    public class ItemVenda
    {
        public int IdVenda { get; set; }
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public double Preco { get; set; }

    }
}
