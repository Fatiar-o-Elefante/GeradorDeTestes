using GeradorDeTestes.Dominio.ModuloQuestoes;
using GeradorDeTestes.WinForms.Compartilhado;

namespace GeradorDeTestes.WinForms.ModuloQuestoes
{
    public class ControladorQuestoes : ControladorBase
    {
        TabelaQuestoesControl tabelaQuestoes;
        private IRepositorioQuestoes repositorioQuestoes;

        public override string ToolTipInserir => throw new NotImplementedException();

        public override string ToolTipEditar => throw new NotImplementedException();

        public override string ToolTipExcluir => throw new NotImplementedException();


        public override void Inserir()
        {
            TelaQuestoesForm telaQuestoes = new TelaQuestoesForm();

            DialogResult opcaoEscolhida = telaQuestoes.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Questoes questao = telaQuestoes.ObterQuestao();

                repositorioQuestoes.Inserir(questao);
            }
            CarregarQuestoes();
        }


        public override void Editar()
        {
            Questoes questaoSelecionada = ObterQuestaoSelecionada();

            if (questaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma questão primeiro", "Edição de Questão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            TelaQuestoesForm telaQuestao = new TelaQuestoesForm();
            telaQuestao.Text = "Editar questão existente";

            telaQuestao.ConfigurarTela(questaoSelecionada);

            DialogResult opcaoEscolhida = telaQuestao.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Questoes questao = telaQuestao.ObterQuestao();

                repositorioQuestoes.Editar(questao.id, questao);
            }

            CarregarQuestoes();
        }

        public override void Excluir()
        {
            Questoes questao = ObterQuestaoSelecionada();

            if (questao == null)
            {
                MessageBox.Show($"Selecione uma questao primeiro!",
                    "Exclusão de Questões",
                    MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a questão?", "Exclusão de Questões",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioQuestoes.Excluir(questao);
            }

            CarregarQuestoes();
        }

        private Questoes ObterQuestaoSelecionada()
        {
            int id = tabelaQuestoes.ObterIdSelecionado();

            return repositorioQuestoes.SelecionarPorId(id);
        }


        private void CarregarQuestoes()
        {
            List<Questoes> listaQuestoes = repositorioQuestoes.SelecionarTodos();

            tabelaQuestoes.AtualizarRegistros(listaQuestoes);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaQuestoes == null)
                tabelaQuestoes = new TabelaQuestoesControl();

            CarregarQuestoes();

            return tabelaQuestoes;
        }

        public override string ObterTipoCadastro()
        {
            return "Registro de Questão";
        }
    }
}
