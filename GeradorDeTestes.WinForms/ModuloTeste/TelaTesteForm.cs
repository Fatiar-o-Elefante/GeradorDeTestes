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
        private List<Teste> testes;
        private IRepositorioMateria repositorioMateria;
        private bool duplicar;

        public TelaTesteForm(bool duplicar, List<Materia> materias, List<Disciplina> disciplinas, List<Questao> questoes, List<Teste> testes, IRepositorioMateria repositorioMateria)
        {
            this.duplicar = duplicar;
            this.questoes = questoes;
            this.testes = testes;

            InitializeComponent();
            this.ConfigurarDialog();

            ConfigurarComboBoxDisciplina(disciplinas);
            ConfigurarComboBoxMateria(materias);
            this.testes = testes;
            this.repositorioMateria = repositorioMateria;
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

        public List<Questao> ObterQuestoesSorteadas()
        {
            return listBoxSorteadas.Items.Cast<Questao>().ToList();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Teste teste = ObterTeste();

            ValidarErros(teste);

            ValidarDuplicacao(teste, duplicar);
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

            foreach (Teste t in testes)
            {
                if (teste.Titulo.ToUpper() == t.Titulo.ToUpper() && teste.id != t.id)
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape("O título já esta em uso");

                    DialogResult = DialogResult.None;
                }
            }
        }

        public void ValidarDuplicacao(Teste teste, bool duplicar)
        {
            if (duplicar == true)
            {
                foreach (Teste t in testes)
                {
                    if (teste.Titulo.ToUpper() == t.Titulo.ToUpper())
                    {
                        TelaPrincipalForm.Instancia.AtualizarRodape("O título já esta em uso");

                        DialogResult = DialogResult.None;
                    }
                }
            }
        }

        private void btnSortear_Click(object sender, EventArgs e)
        {
            int quantidade = (int)numQtdQuestoes.Value;

            if (cbMateria.SelectedItem != null)
            {
                if (quantidade > 0)
                {
                    Materia materiaSelecionada = (Materia)cbMateria.SelectedItem;

                    if (questoes.Count >= quantidade)
                    {
                        List<Questao> questoesSorteadas = SortearQuestoes(questoes, quantidade);

                        questoesSorteadas.ForEach(q => listBoxSorteadas.Items.Add(q));
                    }
                    else
                    {
                        MessageBox.Show("Não há questões suficientes para a quantidade solicitada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Digite uma quantidade válida!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Selecione uma matéria!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnSortear.Enabled = false;
        }

        private List<Questao> SortearQuestoes(List<Questao> questoesDisponiveis, int quantidade)
        {
            List<Questao> questoesSorteadas = new List<Questao>();
            Random random = new Random();
            Materia materia = (Materia)cbMateria.SelectedItem;

            List<Questao> questoesFiltradas = questoesDisponiveis.FindAll(x => x.Materia.id == materia.id);

            for (int i = 0; i < quantidade; i++)
            {
                if (questoesFiltradas.Count == 0)
                    break;

                int index = random.Next(questoesFiltradas.Count);
                questoesSorteadas.Add(questoesFiltradas[index]);
                questoesFiltradas.RemoveAt(index);
            }

            return questoesSorteadas;
        }

        private void cbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMateria.Items.Clear();

            if (cbDisciplina.SelectedItem != null)
            {
                Disciplina disciplinaSelecionada = (Disciplina)cbDisciplina.SelectedItem;

                List<Materia> materiasRelacionadas = repositorioMateria.CarregarMateriasDisciplina(disciplinaSelecionada);

                cbMateria.Items.AddRange(materiasRelacionadas.ToArray());
            }
        }
    }
}
