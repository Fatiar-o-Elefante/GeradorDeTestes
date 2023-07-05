using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestoes;
using GeradorDeTestes.WinForms.Compartilhado;

namespace GeradorDeTestes.WinForms.ModuloQuestoes
{
    public partial class TelaQuestoesForm : Form
    {
        private Questao questao;

        public TelaQuestoesForm(List<Materia> materias)
        {
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
            string repostaCerta = chListAlternativas.CheckedItems[0].ToString()!;

            questao = new Questao(id, materia, enunciado, repostaCerta);

            foreach (Alternativa alternativa in chListAlternativas.Items.Cast<Alternativa>().ToList())
            {
                questao.ListAlternativas.Add(alternativa);
            }

            return questao;
        }

        public Alternativa ObterAlternativa(Questao questao)
        {
            string resposta = txtResposta.Text;

            return new Alternativa(questao, resposta);
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
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Alternativa alternativa = ObterAlternativa(questao);

            chListAlternativas.Items.Add(alternativa);
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

        public List<Alternativa> ObterAlternativasMarcadas()
        {
            return chListAlternativas.CheckedItems.Cast<Alternativa>().ToList();
        }

        public List<Alternativa> ObterAlternativasDesmarcadas()
        {
            return chListAlternativas.Items.Cast<Alternativa>()
                .Except(ObterAlternativasMarcadas()).ToList();
        }
    }
}
