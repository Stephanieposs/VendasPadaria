using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VendasPadaria.Data;
using VendasPadaria.Models;

namespace VendasPadaria.Pages.ClientesRegistrados
{
    public class EditModel : PageModel
    {
        private readonly VendasPadaria.Data.VendasPadariaContext _context;

        public EditModel(VendasPadaria.Data.VendasPadariaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClienteRegistrado ClienteRegistrado { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteregistrado =  await _context.ClienteRegistrado.FirstOrDefaultAsync(m => m.Id == id);
            if (clienteregistrado == null)
            {
                return NotFound();
            }
            ClienteRegistrado = clienteregistrado;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ClienteRegistrado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteRegistradoExists(ClienteRegistrado.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClienteRegistradoExists(int id)
        {
            return _context.ClienteRegistrado.Any(e => e.Id == id);
        }
    }
}
