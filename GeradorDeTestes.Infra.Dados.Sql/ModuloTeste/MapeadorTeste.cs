using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloTestes;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;
using GeradorDeTestes.Infra.Dados.Sql.ModuloDisciplina;
using GeradorDeTestes.Infra.Dados.Sql.ModuloMateria;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.Dados.Sql.ModuloTestes
{
    public class MapeadorTeste : MapeadorBase<Teste>
    {
        public override void ConfigurarParametros(SqlCommand comando, Teste registro)
        {
            comando.Parameters.AddWithValue("@ID", registro.id);
            comando.Parameters.AddWithValue("@TITULO", registro.Titulo);
            comando.Parameters.AddWithValue("@DISCIPLINA_ID", registro.Disciplina.id);
            comando.Parameters.AddWithValue("@MATERIA_ID", registro.Materia.id);
            comando.Parameters.AddWithValue("@QUANTIDADEQUESTOES", registro.QuantidadeQuestoes);
            comando.Parameters.AddWithValue("@PROVARECUPERACAO", registro.ProvaRecuperacao);
        }

        public override Teste ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["TESTE_ID"]);

            string titulo = Convert.ToString(leitorRegistros["TESTE_TITULO"])!;

            int quantidadeDeQuestoes = Convert.ToInt32(leitorRegistros["TESTE_QUANTIDADEQUESTOES"])!;
            bool provaDeRecuperacao = Convert.ToBoolean(leitorRegistros["TESTE_PROVARECUPERACAO"])!;

            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitorRegistros);

            Materia materia = null;
            if (leitorRegistros["MATERIA_ID"] != DBNull.Value)
            {
                materia = new MapeadorMateria().ConverterRegistro(leitorRegistros);
            }

            Teste teste = new Teste(id, titulo, disciplina, materia, quantidadeDeQuestoes, provaDeRecuperacao);

            return teste;
        }
    }
}
