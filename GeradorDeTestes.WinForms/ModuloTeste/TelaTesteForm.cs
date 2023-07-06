using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestoes;
using GeradorDeTestes.Dominio.ModuloTestes;
using GeradorDeTestes.WinForms.Compartilhado;

namespace GeradorDeTestes.WinForms.ModuloTestes
{
    public partial class TelaTesteForm : Form
    {
        private List<Questao> questoes;

        public TelaTesteForm(List<Materia> materias, List<Disciplina> disciplinas, List<Questao> questoes)
        {
            this.questoes = questoes;

            InitializeComponent();
            this.ConfigurarDialog();

            ConfigurarComboBoxDisciplina(disciplinas);
            ConfigurarComboBoxMateria(materias);
        }

        public Teste ObterTeste()
        {
            int id = int.Parse(txtId.Text);
            string titulo = txtTitulo.Text;
            Disciplina disciplina = (Disciplina)cbDisciplina.SelectedItem;
            Materia materia = (Materia)cbMateria.SelectedItem;
            int quantidadeDeQuestoes = int.Parse(numQtdQuestoes.Text);
            bool provaRecuperacao = chProvaRecup.Checked;

            Teste teste = new Teste(id, titulo, disciplina, materia, quantidadeDeQuestoes, provaRecuperacao);
            teste.id = id;

            return teste;
        }

        public void ConfigurarTela(Teste testeSelecionado)
        {
            txtId.Text = testeSelecionado.id.ToString();
            txtTitulo.Text = testeSelecionado.Titulo;
            cbDisciplina.Text = testeSelecionado.Disciplina.ToString();
            cbMateria.Text = testeSelecionado.Materia.ToString();
            numQtdQuestoes.Value = testeSelecionado.QuantidadeQuestoes;
            chProvaRecup.Checked = testeSelecionado.ProvaRecuperacao;
        }

        public void ConfigurarComboBoxDisciplina(List<Disciplina> disciplinas)
        {
            foreach (Disciplina disciplina in disciplinas)
            {
                cbDisciplina.Items.Add(disciplina);
            }
        }

        public void ConfigurarComboBoxMateria(List<Materia> materias)
        {
            foreach (Materia materia in materias)
            {
                cbMateria.Items.Add(materia);
            }
        }

        private void ValidarErros(Teste teste)
        {
            if (teste == null) return;

            string[] erros = teste.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }

        private void btnSortear_Click_1(object sender, EventArgs e)
        {
            int quantidade = (int)numQtdQuestoes.Value;
            Random random = new Random();

            listBoxSorteadas.Items.Clear();

            while (quantidade > 0)
            {
                int indiceSorteado = random.Next(questoes.Count);
                Questao questaoSorteada = questoes[indiceSorteado];

                listBoxSorteadas.Items.Add(questaoSorteada);
                quantidade--;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Teste teste = ObterTeste();

            ValidarErros(teste);
        }
    }
}
