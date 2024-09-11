namespace VendasPadaria.Models
{
    public class ClienteRegistrado : Cliente
    {
        

        public ClienteRegistrado(int id, string nome, string cpf, int pontos): base(id, nome, cpf, pontos) 
        { 
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Pontos = pontos;

        }

        public ClienteRegistrado() { }
    }
}
