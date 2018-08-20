using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Conexao
    {
        private static string connectionString;

        static Conexao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public SqlConnection ObterConexao()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;

        }

    }
}
