using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestoes;
using GeradorDeTestes.WinForms.Compartilhado;

namespace GeradorDeTestes.WinForms.ModuloQuestoes
{
    public partial class TelaQuestaoForm : Form
    {
        private Questao questao;
        List<Questao> questoes;
        private int alternativaCount = 0;

        public TelaQuestaoForm(List<Materia> materias, List<Questao> questoes)
        {
            this.questoes = questoes;

            InitializeComponent();

            this.ConfigurarDialog();

            CarregarMaterias(materias);
        }

        public void CarregarMaterias(List<Materia> materias)
        {
            cbMateria.Items.Clear();

            foreach (Materia materia in materias)
            {
                cbMateria.Items.Add(materia);
            }
        }

        public Questao ObterQuestao()
        {
            int id = int.Parse(txtId.Text);
            string enunciado = txtEnunciado.Text;
            Materia materia = (Materia)cbMateria.SelectedItem;
            string respostaCerta = null;

            questao = new Questao(id, materia, enunciado);

            Alternativa alternativaCorreta = ObterAlternativaMarcada();

            if (chListAlternativas.Items.Count == 0)
                return null;

            if (chListAlternativas.CheckedItems.Count == 0)
                return null;

            else
            {
                respostaCerta = ObterAlternativaMarcada().ToString();
            }

            questao.RespostaCerta = respostaCerta;

            foreach (Alternativa alternativa in ObterAlternativasDesmarcadas())
            {
                questao.AdicionarAlternativa(alternativa);
            }


            alternativaCorreta.Correta = true;
            questao.AdicionarAlternativa(alternativaCorreta);

            return questao;
        }

        public Alternativa ObterAlternativa(Questao questao)
        {
            string resposta = txtResposta.Text;

            return new Alternativa(questao, resposta, false);
        }

        public void ConfigurarTela(Questao questao)
        {
            txtId.Text = questao.id.ToString();
            txtEnunciado.Text = questao.Enunciado;
            cbMateria.Text = questao.Materia.ToString();

            foreach (Alternativa alternativa in questao.ListaAlternativas)
            {
                chListAlternativas.Items.Add(alternativa);
            }

            int i = 0;

            for (int j = 0; j < chListAlternativas.Items.Count; j++)
            {
                Alternativa alternativa = (Alternativa)chListAlternativas.Items[j];

                if (alternativa.Correta)
                {
                    if (questao.ListaAlternativas.Contains(alternativa))
                    {
                        chListAlternativas.SetItemChecked(j, true);
                    }

                    i++;
                }
            }
        }

        public List<Alternativa> ObterAlternativasDaLista()
        {
            return chListAlternativas.Items.Cast<Alternativa>().ToList();
        }

        public Alternativa ObterAlternativaMarcada()
        {
            return chListAlternativas.Items.Cast<Alternativa>().FirstOrDefault(x => x.Correta == true);
        }

        public List<Alternativa> ObterAlternativasDesmarcadas()
        {
            return chListAlternativas.Items.Cast<Alternativa>()
                .Except(chListAlternativas.CheckedItems.Cast<Alternativa>()).ToList();
        }
        
        private void btnRemover_Click(object sender, EventArgs e)
        {
            chListAlternativas.Items.Remove(chListAlternativas.SelectedItem);
        }

        private void chListAlternativas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = chListAlternativas.SelectedIndex;

            int count = chListAlternativas.Items.Count;

            for (int x = 0; x < count; x++)
            {
                if (index != x)
                {
                    chListAlternativas.SetItemCheckState(x, CheckState.Unchecked);
                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Questao questao = ObterQuestao();

            if (questao == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Nenhuma alternativa foi marcada");
                DialogResult = DialogResult.None;
                return;
            }

            ValidarErros(questao);
        }

        private void ValidarErros(Questao questao)
        {
            string[] erros = questao.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

            foreach (Questao q in questoes)
            {
                if (questao.Enunciado.ToUpper() == q.Enunciado.ToUpper() && questao.id != q.id)
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape("O Enunciado já esta em uso");

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Alternativa alternativa = ObterAlternativa(questao);

            if (alternativa.Resposta == "")
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("É necessário ter uma resposta");
                return;
            }

            alternativa.Resposta = $"{txtResposta.Text}";

            alternativaCount++;

            chListAlternativas.Items.Add(alternativa);
            txtResposta.Text = string.Empty;
        }
    }
}
