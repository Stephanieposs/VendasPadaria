namespace VendasPadaria.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public IEnumerable<ItemVenda> ItensList { get; set; }


        public DateTime Data { get; set; }

        public ClienteRegistrado Cliente { get; set; }
        public int ClienteRegistradoId { get; set; }

    }
}
