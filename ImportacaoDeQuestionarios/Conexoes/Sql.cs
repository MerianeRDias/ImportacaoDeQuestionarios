using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeQuestionarios.Conexoes

{
    public class Sql
    {
        private readonly SqlConnection _conexao;

        public Sql()
        {
            string conexao = System.IO.File.ReadAllText(@"C:\Users\Meriane\Documents\RumoAcademy\VisualStudio\conexao\stringConexao.txt");
            this._conexao = new SqlConnection(conexao);

        }

        public void InserirDados(Entidades.Cliente cliente)
        {
            try
            {
                _conexao.Open();

                string sql = @"INSERT INTO Cliente
                                (Cpf,Nome,Genero,Idade,Nacionalidade)
                               VALUES
                                (@cpf, @nome, @sexo , @idade, @nacionalidade);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("sexo", cliente.Sexo);
                    cmd.Parameters.AddWithValue("idade", cliente.Idade);
                    cmd.Parameters.AddWithValue("nacionalidade", cliente.Nacionalidade);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }

        }

    }
}
