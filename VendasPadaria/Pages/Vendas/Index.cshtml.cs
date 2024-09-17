using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VendasPadaria.Models;

namespace VendasPadaria.Pages.Venda
{
    public class IndexModel : PageModel
    {
       

        
        private readonly VendasPadaria.Data.VendasPadariaContext _context;

        public IndexModel(VendasPadaria.Data.VendasPadariaContext context)
            {
                _context = context;
        }

        //public  Venda vendas {  get; set; }
        public IList<ItemVenda> Itens { get; set; } = default!;
        

        // Propriedades para armazenar as listas de Clientes e Produtos
        public IEnumerable<SelectListItem> ClientesList { get; set; } = default!;
        public IEnumerable<Produto> ProdutosList { get; set; } = default!;

        public async Task OnGetAsync()
        {

            Itens = await _context.ItemVendas.ToListAsync();

            //ProdutosList = await _context.Produto.ToListAsync();

            //ClientesList = await _context.ClienteRegistrado.ToListAsync();

        }

        

        // Propriedade para armazenar o cliente selecionado
        [BindProperty]
        public string SelectedCliente { get; set; }

        // Propriedade para armazenar o produto selecionado
        [BindProperty]
        public string SelectedProduto { get; set; }

        
        

    }
}
