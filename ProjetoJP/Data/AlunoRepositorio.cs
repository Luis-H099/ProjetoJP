using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJP.Data
{
    public class AlunoRepositorio
    {
        private SqlConnection _conn;
        public AlunoRepositorio(SqlConnection conn)
        {
            _conn = conn;
        }

        public string InserirAluno(Conexao db, Aluno aluno)
        {
            try
            {
                string sql = $"INSERT INTO Aluno (Nome, Idade, Cpf) VALUES('{aluno.Nome}', {aluno.Idade}, '{aluno.Cpf}')";
                SqlCommand comando = new SqlCommand(sql, db.conn);

                comando.ExecuteNonQuery();

                return "Aluno inserido com sucesso!";
            }
            catch (Exception e)
            {

                return "Erro ao inserir Aluno";
            }
        }

        public List<Aluno> BuscarAlunos(Conexao db)
        {
            string sql = "select Nome, Idade, Cpf from Aluno";
            SqlCommand comando = new SqlCommand(sql, db.conn);

            List<Aluno> alunos = new List<Aluno>();

            using (var reader = comando.ExecuteReader())
            {
                //cria um leitor do ADO.net

                while (reader.Read())
                {///vai lendo cada item do resultado do select
                 ///retorna cada item encontrado
                    var nomeDb = reader.GetString(reader.GetOrdinal("Nome"));
                    var idadeDb = reader.GetInt32(reader.GetOrdinal("Idade"));
                    var cpfDb = reader.GetString(reader.GetOrdinal("Cpf"));

                    alunos.Add(new Aluno()
                    {
                        Nome = nomeDb,
                        Idade = idadeDb,
                        Cpf = cpfDb
                    });

                }
                return alunos;
            }
        }

        public string EditarAluno(Conexao db, Aluno aluno)
        {
            try
            {
                string sql = @"Update Aluno SET Nome = @Nome, Idade = @Idade, Cpf = @Cpf Where Id = @Id";
                using (SqlCommand comando = new SqlCommand(sql, db.conn))
                {
                    comando.Parameters.AddWithValue("@Id", aluno.Id);
                    comando.Parameters.AddWithValue("@Nome", aluno.Nome);
                    comando.Parameters.AddWithValue("@Idade", aluno.Idade);
                    comando.Parameters.AddWithValue("@DataNascimento", aluno.DataNascimento);
                    comando.Parameters.AddWithValue("@Cpf", aluno.Cpf);
                    comando.Parameters.AddWithValue("@Cep", aluno.Cep);
                    comando.Parameters.AddWithValue("@Endereco", aluno.Endereco);
                    comando.Parameters.AddWithValue("@Numero", aluno.Numero);
                    comando.Parameters.AddWithValue("@Bairro", aluno.Bairro);
                    comando.Parameters.AddWithValue("@Cidade", aluno.Cidade);
                    comando.Parameters.AddWithValue("@Estado", aluno.Estado);
                    comando.Parameters.AddWithValue("@Nota1", aluno.Nota1);
                    comando.Parameters.AddWithValue("@Nota2", aluno.Nota2);


                    comando.ExecuteNonQuery();

                    return "Aluno editado com sucesso";

                }
            }
            catch (Exception e)
            {

                return "Erro ao editar Aluno";
            }
        }


        public Aluno BuscarAlunoPorId(int id)
        {
            string sql = "SELECT * FROM Aluno WHERE Id = @Id";
            using (SqlCommand comando = new SqlCommand(sql, _conn))
            {
                comando.Parameters.AddWithValue("@Id", id);
                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Aluno()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nome = reader.GetString(reader.GetOrdinal("Nome")),
                            Idade = reader.GetInt32(reader.GetOrdinal("Idade")),
                            DataNascimento = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DataNascimento"))),
                            Cpf = reader.GetString(reader.GetOrdinal("Cpf")),
                            Cep = reader.GetString(reader.GetOrdinal("Cep")),
                            Endereco = reader.GetString(reader.GetOrdinal("Endereco")),
                            Numero = reader.GetString(reader.GetOrdinal("Numero")),
                            Bairro = reader.GetString(reader.GetOrdinal("Bairro")),
                            Cidade = reader.GetString(reader.GetOrdinal("Cidade")),
                            Estado = reader.GetString(reader.GetOrdinal("Estado")),
                            Nota1 = reader.GetDouble(reader.GetOrdinal("Nota1")),
                            Nota2 = reader.GetDouble(reader.GetOrdinal("Nota2")),
                        };
                    }
                }
            }
            return null;
        }

    }
}


