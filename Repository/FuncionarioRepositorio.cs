using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class FuncionarioRepositorio
    {
        public List<Funcionario> ObterTodos()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            SqlConnection conexao = new Conexao().ObterConexao();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT * FROM funcionarios";
            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());
            foreach (DataRow tableRow in table.Rows)
            {
                funcionarios.Add(new Funcionario()
                {
                    Id = Convert.ToInt32(tableRow["id"].ToString()),
                    Nome = tableRow["nome"].ToString(),
                    Idade = Convert.ToInt32(tableRow["idade"].ToString()),
                    Salario = Convert.ToDecimal(tableRow["salario"].ToString())
                });
            }
            conexao.Close();
            return funcionarios;
        }

        public int Inserir(Funcionario funcionario)
        {
            SqlConnection conexao = new Conexao().ObterConexao();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "INSERT INTO funcionarios (nome, idade, salario)  OUTPUT INSERTED.ID VALUES (@NOME, @IDADE, @SALARIO)";
            comando.Parameters.AddWithValue("@NOME", funcionario.Nome);
            comando.Parameters.AddWithValue("@IDADE", funcionario.Idade);
            comando.Parameters.AddWithValue("@SALARIO", funcionario.Salario);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            conexao.Close();
            return id;
        }
    }
}
