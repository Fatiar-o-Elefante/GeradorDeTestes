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
        public List<Questao> questoesSorteadas { get; set; } = new List<Questao>();
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
            listBoxSorteadas.Items.Clear();
            questoesSorteadas.Clear();

            Materia materia = (Materia)cbMateria.SelectedItem;
            Disciplina disciplina = (Disciplina)cbDisciplina.SelectedItem;

            int quantidade = (int)numQtdQuestoes.Value;            

            if (cbMateria.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma matéria!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (quantidade <= 0)
            {
                MessageBox.Show("Digite uma quantidade válida!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Materia materiaSelecionada = (Materia)cbMateria.SelectedItem;

            List<Questao> questoesParaSortear;

            if (chProvaRecup.Checked == false)
            {
                questoesParaSortear = questoes.FindAll(x => x.Materia.id == materia.id);
            }
            else
            {
                questoesParaSortear = questoes.FindAll(q => q.Materia.Disciplina.id == disciplina.id);
            }

            if (questoesParaSortear.Count < quantidade)
            {
                MessageBox.Show("Não há questões suficientes para a quantidade solicitada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Random random = new Random();

            while (questoesSorteadas.Count < quantidade)
            {
                int index = random.Next(questoesParaSortear.Count);
                questoesSorteadas.Add(questoesParaSortear[index]);
                questoesParaSortear.RemoveAt(index);
            }

            questoesSorteadas.ForEach(q => listBoxSorteadas.Items.Add(q));
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

        private void ValidarErros(Teste teste)
        {
            if (teste == null) return;

            string[] erros = teste.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

            if (testes.Contains(teste))
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("O título já esta em uso");

                DialogResult = DialogResult.None;
            }

            if (listBoxSorteadas.Items.Count == 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("É necessário sortear questões");

                DialogResult = DialogResult.None;
            }
        }
    }
}
