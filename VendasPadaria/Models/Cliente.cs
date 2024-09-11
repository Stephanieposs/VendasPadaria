namespace VendasPadaria.Models
{
    public abstract class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Pontos { get; set; }


        public Cliente(int id, string nome, string cpf, int pontos) 
        { 
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Pontos = pontos;
        }

        public Cliente() { }

    }
}
