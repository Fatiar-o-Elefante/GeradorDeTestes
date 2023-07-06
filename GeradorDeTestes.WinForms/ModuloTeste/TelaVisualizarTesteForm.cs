using GeradorDeTestes.Dominio.ModuloQuestoes;
using GeradorDeTestes.Dominio.ModuloTestes;
using GeradorDeTestes.WinForms.Compartilhado;

namespace GeradorDeTestes.WinForms.ModuloTestes
{
    public partial class TelaVisualizarTesteForm : Form
    {
        public TelaVisualizarTesteForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public void AtualizarLista(List<Questao> questoes)
        {
            listBoxQuestoes.Items.Clear();

            foreach (Questao questao in questoes)
            {
                listBoxQuestoes.Items.Add("  ★ " + questao);
            }
        }

        public void CarregarLista(List<Questao> questoes)
        {
            AtualizarLista(questoes);
        }

        public void CarregarLabel(Teste testes)
        {
            lblDisciplina.Text = testes.Disciplina.ToString();
            lblTitulo.Text = testes.Titulo;
            lblMateria.Text = testes.Materia.ToString();
        }
    }
}
