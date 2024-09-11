using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VendasPadaria.Data;
using VendasPadaria.Models;

namespace VendasPadaria.Pages.Vendas
{
    public class IndexModel : PageModel
    {
        private readonly VendasPadaria.Data.VendasPadariaContext _context;

        public IndexModel(VendasPadaria.Data.VendasPadariaContext context)
        {
            _context = context;
        }

        public IList<Venda> Venda { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Venda = await _context.Vendas
                .Include(v => v.Produto).ToListAsync();
        }
    }
}
