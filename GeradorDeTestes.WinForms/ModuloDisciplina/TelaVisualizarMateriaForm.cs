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

namespace GeradorDeTestes.WinForms.ModuloDisciplina
{
    public partial class TelaVisualizarMateriaForm : Form
    {
        public TelaVisualizarMateriaForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public void AtualizarLista(List<Materia> materias)
        {
            listMaterias.Items.Clear();

            foreach (Materia materia in materias)
            {
                listMaterias.Items.Add("  ★ " + materia);
            }
        }

        public void CarregarLista(List<Materia> materias)
        {
            AtualizarLista(materias);
        }

        public void CarregarLabel(Disciplina disciplina)
        {
            lblDisciplina.Text = disciplina.Nome;
        }
    }
}
