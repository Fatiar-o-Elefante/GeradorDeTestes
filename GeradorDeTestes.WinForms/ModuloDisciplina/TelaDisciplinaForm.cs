using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.WinForms.Compartilhado;

namespace GeradorDeTestes.WinForms.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form
    {

        private Disciplina disciplina;
        private List<Disciplina> disciplinas;

        public TelaDisciplinaForm(List<Disciplina> disciplinas)
        {
            this.disciplinas = disciplinas;

            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Disciplina ObterDisciplina()
        {
            int id = Convert.ToInt32(txtId.Text);
            string nome = txtNome.Text;

            Disciplina disciplina = new Disciplina(id, nome);

            return disciplina;

        }

        public void ConfigurarTela(Disciplina disciplinaSelecionada)
        {
            txtId.Text = disciplinaSelecionada.id.ToString();
            txtNome.Text = disciplinaSelecionada.Nome;
        }
        private void ValidarErros(Disciplina disciplina)
        {
            string[] erros = disciplina.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

            foreach (Disciplina d in disciplinas)
            {
                if (disciplina.Nome == d.Nome && txtId.Text == "0")
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape("O nome ja esta em uso");

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            Disciplina disciplina = ObterDisciplina();

            ValidarErros(disciplina);
        }
    }
}
