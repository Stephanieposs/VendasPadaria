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

namespace VendasPadaria.Pages.Vendas
{
    public class CreateModel : PageModel
    {
        private readonly VendasPadaria.Data.VendasPadariaContext _context;

        public CreateModel(VendasPadaria.Data.VendasPadariaContext context)
        {
            _context = context;
        }

        //public List<SelectListItem> ProdutoList { get; set; }

        public IActionResult OnGet()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id");
            /*
            ProdutoList = _context.Produto
           .AsNoTracking()
           .OrderBy(p => p.Nome)
           .Select(p => new SelectListItem
           {
               Value = p.Id.ToString(),
               Text = $"{p.Id} - {p.Nome}"
           })
           .ToList();
            */
            //_context.Produto.ToList();
            return Page();
        }

        [BindProperty]
        public Venda Venda { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Produto produto = _context.Produto.FirstOrDefault(c => c.Id == Venda.ProdutoId);

            if (produto != null)
            {
                Venda.Produto = produto;
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vendas.Add(Venda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
