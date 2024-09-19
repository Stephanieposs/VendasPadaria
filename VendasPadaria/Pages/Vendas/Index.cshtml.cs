using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
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

        // Propriedades para armazenar as listas 
        public IList<Venda> Vendas { get; set; } = new List<Venda>();
        public IList<ItemVenda> ItemVendas { get; set; } = new List<ItemVenda>();
        public IEnumerable<SelectListItem> ClientesList { get; set; } = default!;
        public IEnumerable<Produto> ProdutosList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //Venda vendaNew = new Venda();
            //Vendas.Add(vendaNew);

            //ItensList = await _context.ItemVendas.ToListAsync();
            ItemVendas = await _context.ItemVendas.ToListAsync() ?? new List<ItemVenda>();


            // Popula a lista de clientes com a propriedade SelectListItem
            ClientesList = await _context.ClienteRegistrado
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome + " - Cpf: " + c.Cpf
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

        [TempData]
        public string Mensagem { get; set; }

        [BindProperty]
        public int QuantidadeProd { get; set; }
        
        

        public async Task<IActionResult> OnPostAdicionarAsync()
        {

            if (IdSelectedCliente == 0 || IdSelectedProduto == 0 || QuantidadeProd < 1)
            {
                Mensagem = "Selecione um cliente, um produto e informe uma quantidade válida.";
                return Page();
            }

            var produto = await _context.Produto.FindAsync(IdSelectedProduto);
            if (produto == null)
            {
                Mensagem = "Produto não encontrado.";
                return Page();
            }

            /*
            if (Vendas == null || Vendas.Count == 0)
            {
                Mensagem = "Nenhuma venda encontrada.";
                return Page();
            }   */

            ItemVenda novoItem = new ItemVenda()
            {
                //Id = ItensList.Count+1,
                //VendaId = Vendas[Vendas.Count-1].Id,
                Produto = produto,
                ProdutoId = produto.Id,
                //ProdutoId = IdSelectedProduto,
                Quantidade = QuantidadeProd
            };


            if (ItemVendas == null)
            {
                //throw new Exception("ItensList vazia");
                ItemVendas = new List<ItemVenda>(); // Inicialize a lista se for nula
            }
            ItemVendas.Add(novoItem);


            _context.ItemVendas.Add(novoItem);
            await _context.SaveChangesAsync();

            var cliente = await _context.ClienteRegistrado.FindAsync(IdSelectedCliente);
            if (cliente == null)
            {
                Mensagem = "Cliente não encontrado.";
                return Page();
            }

            Mensagem = $"Cliente {IdSelectedCliente}, Produto {IdSelectedProduto}, Quantidade {QuantidadeProd} foram adicionados.";


            return Page();
        }

        // Finalizar venda
        public async Task<IActionResult> OnPostFinalizarAsync()
        {
            if (ItemVendas.Count == 0 || IdSelectedCliente == 0)
            {
                Mensagem = "Adicione itens à venda e selecione um cliente.";
                return Page();
            }

            // Criar nova venda
            var novaVenda = new Venda
            {
                ClienteRegistradoId = IdSelectedCliente,
                Data = DateTime.Now,
                //ItensList = ItensList,
                //Itens = Itens,
                //Id = Vendas.Count + 1

            };

            //Vendas[Vendas.Count-1].ClienteRegistradoId = (IdSelectedCliente);
            //Vendas[Vendas.Count-1].Data = (DateTime.Now);

            _context.Vendas.Add(novaVenda); // Adicionar a venda no contexto
            await _context.SaveChangesAsync(); // Salvar no banco

            // Limpar a lista de itens temporários
            //ItensList.Clear();
            Mensagem = "Venda finalizada com sucesso!";
            return Page();
        }

    }
}
