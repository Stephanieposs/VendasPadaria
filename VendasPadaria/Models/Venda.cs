namespace VendasPadaria.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public double Total;
        private double total
        {
            get { return (Produto.preco * Quantidade); }
            set
            {
                Total = value;
            }
        }

        /*
        public Venda(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
            
        }
        */

        //public Vendas() { }

        

    }
}
