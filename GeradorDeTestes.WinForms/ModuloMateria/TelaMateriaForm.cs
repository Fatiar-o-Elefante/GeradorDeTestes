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
        private List<Materia> materias;

        public TelaMateriaForm(List<Disciplina> disciplinas, List<Materia> materias)
        {
            this.materias = materias;

            InitializeComponent();
            this.ConfigurarDialog();

            CarregarDisciplinas(disciplinas);
        }

        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            cbDisciplina.Items.Clear();

            foreach (Disciplina disciplina in disciplinas)
            {
                cbDisciplina.Items.Add(disciplina);
            }
        }

        public Materia ObterMateria()
        {
            int id = Convert.ToInt32(txtId.Text);
            string nome = txtNome.Text;
            Disciplina disciplina = (Disciplina)cbDisciplina.SelectedItem;
            int serie = 0;

            if (rdbPrimeiro.Checked)
            {
                serie = 1;
            }
            if (rdbSegundo.Checked)
            {
                serie = 2;
            }

            return new Materia(id, nome, disciplina, serie);
        }

        public void ConfigurarTela(Materia materiaSelecionada)
        {
            txtId.Text = materiaSelecionada.id.ToString();
            txtNome.Text = materiaSelecionada.Nome;
            cbDisciplina.Text = materiaSelecionada.Disciplina.ToString();

            if (materiaSelecionada.Serie == 1)
                rdbPrimeiro.Checked = true;
            if (materiaSelecionada.Serie == 2)
                rdbSegundo.Checked = true;
        }

        private void ValidarErros(Materia materia)
        {
            if (materia == null) return;

            string[] erros = materia.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

            foreach (Materia m in materias)
            {
                if (materia.Nome.ToUpper() == m.Nome.ToUpper() && materia.id != m.id)
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape("O nome já esta em uso");

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Materia materia = ObterMateria();

            ValidarErros(materia);
        }
    }
}
