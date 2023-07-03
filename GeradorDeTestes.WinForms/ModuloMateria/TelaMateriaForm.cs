using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.WinForms.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.WinForms.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        private Materia materia;
        List<Materia> listaMaterias;
        public TelaMateriaForm(List<Materia> listaMaterias)
        {
            InitializeComponent();

            this.listaMaterias = listaMaterias;

            this.ConfigurarDialog();
        }

        public Materia ObterMateria()
        {
            int id = Convert.ToInt32(txtId.Text);
            string nome = txtNome.Text;
            SerieEnum serie = (SerieEnum)SelecionarSerie();
            Disciplina disciplina = (Disciplina)cbDisciplina.SelectedItem;

            materia = new Materia(id, nome, disciplina, serie);

            return materia;
        }

        public void ConfigurarTela(Materia materiaSelecionada)
        {
            txtId.Text = materiaSelecionada.id.ToString();
            txtNome.Text = materiaSelecionada.Nome;
            cbDisciplina.Text = materiaSelecionada.Disciplina.ToString();

            switch (materiaSelecionada.Serie)
            {
                case SerieEnum.primeira: rdbPrimeiro.Checked = true; break;
                case SerieEnum.segunda: rdbSegundo.Checked = true; break;
            }
        }

        private Enum SelecionarSerie()
        {
            SerieEnum serie;

            if (rdbPrimeiro.Checked)
            {
                serie = SerieEnum.primeira;
                return serie;
            }

            return serie = SerieEnum.segunda;
        }
    }
}
