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

        public void AtualizarDados(Entidades.Cliente cliente)
        {
            try
            {
                _conexao.Open();

                string sql = @"UPDATE Cliente
                                   SET Nome = @Nome
                                      ,Genero = @Genero
                                      ,Nacionalidade = @Nacionalidade
                                      ,Idade = @Idade
                                 WHERE Cpf = @Cpf";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("Cpf", "32502875611");
                    cmd.Parameters.AddWithValue("Nome", "Sol");
                    cmd.Parameters.AddWithValue("Genero", "F");
                    cmd.Parameters.AddWithValue("Idade", 20);
                    cmd.Parameters.AddWithValue("Nacionalidade", "Brasileira");
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }

        }

        public bool VerificarExistenciaCliente(Entidades.Cliente cliente)
        {
          
         
            try
            {
                _conexao.Open();

                string sql = @"select Count(Cpf) AS total from Cliente WHERE Cpf = @Cpf;";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("cpf", "32502875611");
                    return Convert.ToBoolean(cmd.ExecuteScalar());
                    
                }
            }
            finally
            {
                _conexao.Close();
            }
            

        }
    }

}