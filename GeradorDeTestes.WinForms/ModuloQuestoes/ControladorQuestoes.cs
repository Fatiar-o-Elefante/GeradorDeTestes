using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestoes;
using GeradorDeTestes.WinForms.Compartilhado;

namespace GeradorDeTestes.WinForms.ModuloQuestoes
{
    public class ControladorQuestao : ControladorBase
    {
        private IRepositorioQuestoes repositorioQuestao;
        private TabelaQuestoesControl tabelaQuestao;
        private IRepositorioMateria repositorioMateria;

        public ControladorQuestao(IRepositorioQuestoes repositorioQuestao, IRepositorioMateria repositorioMateria)
        {
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioMateria = repositorioMateria;
        }

        public override string ToolTipInserir => "Enserir Nova Questão";

        public override string ToolTipEditar => "Editar Questão Existente";

        public override string ToolTipExcluir => "Excluir Questão";

        public override void ApresentarMensagem(string mensagem, string titulo)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        public override void Inserir()
        {
            TelaQuestoesForm telaQuestaoForm = new TelaQuestoesForm(repositorioMateria.SelecionarTodos());

            DialogResult opcaoEscolhida = telaQuestaoForm.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Questao questao = telaQuestaoForm.ObterQuestao();

                List<Alternativa> alternativasAdicionadas = telaQuestaoForm.ObterAlternativasMarcadas();

                repositorioQuestao.Inserir(questao, alternativasAdicionadas);
            }

            CarregarQuestoes();
        }


        public override void Editar()
        {
            TelaQuestoesForm telaQuestaoForm = new TelaQuestoesForm(repositorioMateria.SelecionarTodos());

            Questao questaoSelecionada = ObterQuestaoSelecionada();

            telaQuestaoForm.ConfigurarTela(questaoSelecionada);

            DialogResult opcaoEscolhida = telaQuestaoForm.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Questao questao = telaQuestaoForm.ObterQuestao();

                List<Alternativa> alternativasMarcadas = telaQuestaoForm.ObterAlternativasMarcadas();

                List<Alternativa> alternativasDesmarcadas = telaQuestaoForm.ObterAlternativasDesmarcadas();

                repositorioQuestao.Editar(questao.id, questao, alternativasMarcadas, alternativasDesmarcadas);
            }

            CarregarQuestoes();
        }

        private Questao ObterQuestaoSelecionada()
        {
            int id = tabelaQuestao.ObterIdSelecionado();

            return repositorioQuestao.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            Questao questaoSelecionada = ObterQuestaoSelecionada();

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a questão {questaoSelecionada.id}?", "Exclusão de Matérias",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioQuestao.Excluir(questaoSelecionada);
            }

            CarregarQuestoes();
        }


        public override UserControl ObterListagem()
        {
            if (tabelaQuestao == null)

                tabelaQuestao = new TabelaQuestoesControl();

            CarregarQuestoes();

            return tabelaQuestao;
        }

        public override string ObterTipoCadastro()
        {
            return "cadastro de questoes";
        }

        private void CarregarQuestoes()
        {
            List<Questao> questoes = repositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(questoes);
        }
    }
}
