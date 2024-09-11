using Microsoft.Identity.Client;

namespace VendasPadaria.Models
{
    public class CupomFiscal
    {
        public List<Venda> Vendas { get; set; }
        public double TotalVendas
        {
            get
            {
                double total = 0;
                foreach (var item in Vendas)
                {
                    total += item.Total;
                }

                return total;
            }
            set { TotalVendas = value; }
        }

        public Cliente Cliente 
        {
            get
            {
                Cliente.Pontos++; 
                return Cliente;
            }
            set { Cliente = value; }
        
        }
        public int ClienteId { get; set; }
        public string Pagamento { get; set; }

        // adicionar um ponto no Cliente


    }
}
