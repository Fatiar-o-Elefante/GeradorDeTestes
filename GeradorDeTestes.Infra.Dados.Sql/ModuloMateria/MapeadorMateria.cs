using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;
using GeradorDeTestes.Infra.Dados.Sql.ModuloDisciplina;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.Dados.Sql.ModuloMateria
{
    public class MapeadorMateria : MapeadorBase<Materia>
    {
        public override void ConfigurarParametros(SqlCommand comando, Materia registro)
        {
            comando.Parameters.AddWithValue("@ID", registro.id);
            comando.Parameters.AddWithValue("@NOME", registro.Nome);
            comando.Parameters.AddWithValue("@DISCIPLINA_ID", registro.Disciplina.id);
            comando.Parameters.AddWithValue("@SERIE", registro.Serie);
        }

        public override Materia ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["MATERIA_ID"]);
            string nome = Convert.ToString(leitorRegistros["MATERIA_NOME"]);
            int serie = Convert.ToInt32(leitorRegistros["MATERIA_SERIE"]);

            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitorRegistros);

            return new Materia(id, nome, disciplina, serie);
        }
    }
}
