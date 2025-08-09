using System.Data.SqlClient;

namespace ProjetoJP.Data
{
    public class Conexao
    {
        public SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BancoJP;Data Source=DESKTOP-MVO6V3Q\\SQLEXPRESS");

        public void Conectar()
        {
            conn.Open();    
        }

        public void Desconectar()
        {
            conn.Close();
        }
    }
}
