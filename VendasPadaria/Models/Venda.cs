﻿namespace VendasPadaria.Models
{
    public class Venda
    {
        public int IdVenda { get; set; }
        public IEnumerable<ItemVenda> Itens { get; set; }

        public DateTime Data { get; set; }

        public ClienteRegistrado Cliente { get; set; }
        public int ClienteRegistradoId { get; set; }

    }
}
