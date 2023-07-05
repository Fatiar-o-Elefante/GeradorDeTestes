using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestoes;

namespace GeradorDeTestes.WinForms.ModuloQuestoes
{
    public partial class TelaQuestoesForm : Form
    {
        public TelaQuestoesForm()
        {
            InitializeComponent();
        }

        public Questao ObterQuestao()
        {
            int id = Convert.ToInt32(txtId.Text);

            string enunciado = txtEnunciado.Text;

            Materia materia = (Materia)cbMateria.SelectedItem;

            string respostaCerta = chListAlternativas.CheckedItems.ToString();

            List<Alternativa> listaAlaternativas = new List<Alternativa>();

            listaAlaternativas.AddRange(chListAlternativas.Items.Cast<Alternativa>());

            Questao questao = new Questao(materia, enunciado, respostaCerta, listaAlaternativas);

            if (id > 0)
                questao.id = id;

            return questao;
        }

        public void ConfigurarTela(Questao questao)
        {
            ConfigurarListBoxAlternativa(questao.ListAlternativas);

            txtId.Text = questao.id.ToString();

            txtEnunciado.Text = questao.Enunciado;

            cbMateria.SelectedItem = questao.Materia.ToString();

            int i = 0;

            for (int j = 0; j < chListAlternativas.Items.Count; j++)
            {
                Alternativa alternativa = (Alternativa)chListAlternativas.Items[j];

                if (questao.ListAlternativas.Contains(alternativa))
                {
                    chListAlternativas.SetItemChecked(i, true);
                }

                i++;
            }
        }

        public void ConfigurarListBoxAlternativa(List<Alternativa> aternativas)
        {
            chListAlternativas.Items.Clear();

            chListAlternativas.Items.AddRange(aternativas.ToArray());
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Alternativa Alternativa = new Alternativa();
            Alternativa.AlternativaResposta = txtResposta.Text;

            chListAlternativas.Items.Add(Alternativa);
        }
    }
}
