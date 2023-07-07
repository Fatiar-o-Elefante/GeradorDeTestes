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
            string respostaCerta;

            if (chListAlternativas.Items.Count == 0)
                return null;

            if (chListAlternativas.CheckedItems.Count == 0)
                respostaCerta = "erro";
            else
                respostaCerta = chListAlternativas.CheckedItems[0].ToString()!;


            questao = new Questao(id, materia, enunciado, respostaCerta);

            foreach (Alternativa alternativa in ObterAlternativasDesmarcadas())
            {
                questao.AdicionarAlternativa(alternativa);
            }

            foreach (Alternativa alternativaMarcada in ObterAlternativasMarcadas())
            {
                Alternativa alternativa = new Alternativa(questao, respostaCerta, true);
                alternativa.Correta = true;
                questao.AdicionarAlternativa(alternativa);
            }

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

            foreach (Alternativa alternativa in questao.ListAlternativas)
            {
                chListAlternativas.Items.Add(alternativa);
            }

            int i = 0;

            for (int j = 0; j < chListAlternativas.Items.Count; j++)
            {
                Alternativa alternativa = (Alternativa)chListAlternativas.Items[j];

                if (alternativa.Correta)
                {
                    if (questao.ListAlternativas.Contains(alternativa))
                    {
                        chListAlternativas.SetItemChecked(i, true);
                    }

                    i++;
                }
            }
        }

        public List<Alternativa> ObterAlternativasMarcadas()
        {
            return chListAlternativas.CheckedItems.Cast<Alternativa>().ToList();
        }

        public List<Alternativa> ObterAlternativasDesmarcadas()
        {
            return chListAlternativas.Items.Cast<Alternativa>()
                .Except(ObterAlternativasMarcadas()).ToList();
        }

        public void ValidarErros(Questao questao)
        {
            if (questao == null) return;

            string[] erros = questao.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

            foreach (Questao q in questoes)
            {
                if (questao.Enunciado.ToLower() == q.Enunciado.ToLower() && txtId.Text == "0")
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape("O nome ja esta em uso");

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            Alternativa alternativa = ObterAlternativa(questao);

            if (alternativa.Resposta == "")
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("É necessário ter uma resposta");
                return;
            }

            chListAlternativas.Items.Add(alternativa);
        }

        private void btnRemover_Click_1(object sender, EventArgs e)
        {
            chListAlternativas.Items.Remove(chListAlternativas.SelectedItem);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Questao questao = ObterQuestao();

            ValidarErros(questao);
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
    }
}
