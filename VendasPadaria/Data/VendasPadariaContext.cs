using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasPadaria.Models;

namespace VendasPadaria.Data
{
    public class VendasPadariaContext : DbContext
    {
        public VendasPadariaContext (DbContextOptions<VendasPadariaContext> options)
            : base(options)
        {

        }

        public DbSet<VendasPadaria.Models.ClienteRegistrado> ClienteRegistrado { get; set; } = default!;
        public DbSet<VendasPadaria.Models.Produto> Produto { get; set; } = default!;
        public DbSet<VendasPadaria.Models.ItemVenda> ItemVendas { get; set; } = default!;
        //public DbSet<VendasPadaria.Models.Venda> Vendas { get; set; } = default!;
    }
}
