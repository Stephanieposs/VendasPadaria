using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VendasPadaria.Data;
using VendasPadaria.Models;

namespace VendasPadaria.Pages.ClientesRegistrados
{
    public class CreateModel : PageModel
    {
        private readonly VendasPadaria.Data.VendasPadariaContext _context;

        public CreateModel(VendasPadaria.Data.VendasPadariaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ClienteRegistrado ClienteRegistrado { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ClienteRegistrado.Pontos = 0;
            _context.ClienteRegistrado.Add(ClienteRegistrado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
