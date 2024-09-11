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
    public class DetailsModel : PageModel
    {
        private readonly VendasPadaria.Data.VendasPadariaContext _context;

        public DetailsModel(VendasPadaria.Data.VendasPadariaContext context)
        {
            _context = context;
        }

        public ClienteRegistrado ClienteRegistrado { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteregistrado = await _context.ClienteRegistrado.FirstOrDefaultAsync(m => m.Id == id);
            if (clienteregistrado == null)
            {
                return NotFound();
            }
            else
            {
                ClienteRegistrado = clienteregistrado;
            }
            return Page();
        }
    }
}
