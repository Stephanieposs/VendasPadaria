using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VendasPadaria.Data;
using VendasPadaria.Models;

namespace VendasPadaria.Pages.ClientesRegistrados
{
    public class IndexModel : PageModel
    {
        private readonly VendasPadaria.Data.VendasPadariaContext _context;

        public IndexModel(VendasPadaria.Data.VendasPadariaContext context)
        {
            _context = context;
        }

        public IList<ClienteRegistrado> ClienteRegistrado { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ClienteRegistrado = await _context.ClienteRegistrado.ToListAsync();
        }
    }
}
