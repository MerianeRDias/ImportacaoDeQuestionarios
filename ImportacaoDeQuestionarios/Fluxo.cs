using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeQuestionarios
{
    internal class Fluxo
    {
        public List<Entidades.Cliente> LerArquivoDeTexto()
        {

            string[] linhas = System.IO.File.ReadAllLines(@"C:\Users\Meriane\Documents\RumoAcademy\AtividadeAvaliativa\Clientes.txt");

            var clientes = new List<Entidades.Cliente>();


            foreach (string linha in linhas)
            {

                var cliente = new Entidades.Cliente();
                cliente.Cpf = linha.Substring(0, 11);
                cliente.Nome = linha.Substring(11, 80).Trim();
                cliente.Sexo = linha.Substring(91, 1);
                cliente.Idade = int.Parse(linha.Substring(92, 3));
                cliente.Nacionalidade = linha.Substring(95, 20).Trim();


                clientes.Add(cliente);

            }
            return clientes;
        }

        public void ImportacaoDeClientes()
        {
            var clientes = LerArquivoDeTexto();
            var sql = new Conexoes.Sql();
            foreach (var cliente in clientes)
            {
                if (sql.VerificarExistenciaCliente(cliente.Cpf) == true)
                {
                    sql.AtualizarDados(cliente);
                   
                }
                else
                {
                    sql.InserirDados(cliente);
                }
                
               
            }
        }
    }
}
