using Microsoft.Data.SqlClient;
using VendasPadaria.Models;

namespace VendasPadaria.Repository
{
    public class RepoCliente : IRepositorio<Cliente, int>

    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vendas;";
        private List<Cliente> clienteList = new List<Cliente>();

        public Cliente Save(Cliente entity)
        {
            string insertQuery = "insert into tb_clientes(Nome,Cpf)values(@Nome,@Cpf);SELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@Nome", entity.Nome);
                    command.Parameters.AddWithValue("@Cpf", entity.Cpf);
                    connection.Open();
                    entity.Id = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return entity;
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            List<Cliente> clientes = new List<Cliente>();
            string selectQuery = "SELECT Id, Nome, Cpf, Pontos FROM tb_clientes";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new ClienteRegistrado()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Cpf = reader.GetString(reader.GetOrdinal("Cpf")),
                                //pontos = reader.GetInt32(reader.GetOrdinal("Pontos"))
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return clientes;
        }

        public Cliente Get(int id)
        {
            Cliente cliente = null;
            string selectQuery = "SELECT Id, Nome, Cpf, Pontos FROM tb_clientes where id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new ClienteRegistrado
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Cpf = reader.GetString(reader.GetOrdinal("Cpf")),
                                //pontos = reader.GetString(reader.GetOrdinal("Phone"))
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
            return cliente;
        }

        public Cliente Update(Cliente entity)
        {
            string updateQuery = "UPDATE tb_clientes SET Nome = @Nome, Cpf = @Cpf WHERE Id = @Id;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@Id", entity.Id);
                    command.Parameters.AddWithValue("@Nome", entity.Nome);
                    command.Parameters.AddWithValue("@Cpf", entity.Cpf);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }


            }
            return entity;

        }

        public void Delete(Cliente entity)
        {
            string deleteQuery = "DELETE FROM tb_clientes WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", entity.Id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Pessoa excluída com sucesso.");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Could not delete {ex.Message}");
                }
            }
        }

    }
}
