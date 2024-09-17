using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

            

            // Popula a lista de clientes com a propriedade SelectListItem
            ClientesList = await _context.ClienteRegistrado
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome + c.Cpf
                }).ToListAsync();

            // Popula a lista de produtos com a propriedade SelectListItem
            ProdutosList = await _context.Produto.ToListAsync();

        }

        

        // Propriedade para armazenar o cliente selecionado
        [BindProperty]
        public int IdSelectedCliente { get; set; }

        // Propriedade para armazenar o produto selecionado
        [BindProperty]
        public int IdSelectedProduto { get; set; }

        public string Mensagem { get; set; }

        [BindProperty]
        public int Quantidade { get; set; }
        
        

        public async Task<IActionResult> OnPostAdicionarAsync()
        {
            
            if (IdSelectedCliente == 0 || IdSelectedProduto == 0|| Quantidade < 1)
            {
                Mensagem = "Selecione um cliente, um produto e informe uma quantidade válida.";
                return Page();
            }

            var produto = await _context.Produto.FindAsync(IdSelectedProduto);

            Mensagem = $"Cliente {IdSelectedCliente}, Produto {IdSelectedProduto}, Quantidade {Quantidade} foram adicionados.";

            
            Itens[IdSelectedProduto].Quantidade = Quantidade;

            var novaVenda = new ItemVenda
            {
                
                ProdutoId = produto.Id,
                Quantidade = Quantidade,
                Produto = produto
            };

            
             _context.ItemVendas.Add(novaVenda);
            await _context.SaveChangesAsync();


            return Page();
        }

    }
}
