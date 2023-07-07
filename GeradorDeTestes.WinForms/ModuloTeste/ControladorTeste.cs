using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestoes;
using GeradorDeTestes.Dominio.ModuloTestes;
using GeradorDeTestes.WinForms.Compartilhado;

namespace GeradorDeTestes.WinForms.ModuloTestes
{
    public class ControladorTeste : ControladorBase
    {
        private IRepositorioTeste repositorioTeste;
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioQuestao repositorioQuestao;
        private TabelaTesteControl tabelaTeste;

        public ControladorTeste(IRepositorioTeste repositorioTeste, IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.repositorioQuestao = repositorioQuestao;
        }

        public override string ToolTipInserir => "Inserir Teste";

        public override string ToolTipEditar => "Editar Teste";

        public override string ToolTipExcluir => "Excluir Teste Existente";

        public override void Inserir()
        {
            TelaTesteForm telaTestes = new TelaTesteForm(repositorioMateria.SelecionarTodos(),
                repositorioDisciplina.SelecionarTodos(), repositorioQuestao.SelecionarTodos());

            DialogResult opcaoEscolhida = telaTestes.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Teste teste = telaTestes.ObterTeste();

                repositorioTeste.Inserir(teste);
            }
            CarregarTestes();
        }


        public override void Editar()
        {
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro", "Edição de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            TelaTesteForm telaTestes = new TelaTesteForm(repositorioMateria.SelecionarTodos(),
                repositorioDisciplina.SelecionarTodos(), repositorioQuestao.SelecionarTodos());
            telaTestes.Text = "Editar teste existente";

            telaTestes.ConfigurarTela(testeSelecionado);

            DialogResult opcaoEscolhida = telaTestes.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Teste teste = telaTestes.ObterTeste();

                repositorioTeste.Editar(teste.id, teste);
            }

            CarregarTestes();
        }

        public override void Excluir()
        {
            Teste teste = ObterTesteSelecionado();

            if (teste == null)
            {
                MessageBox.Show($"Selecione um teste primeiro!",
                    "Exclusão de Testes",
                    MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir um teste?", "Exclusão de Testes",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioTeste.Excluir(teste);
            }

            CarregarTestes();
        }

        private Teste ObterTesteSelecionado()
        {
            int id = tabelaTeste.ObterIdSelecionado();

            return repositorioTeste.SelecionarPorId(id);
        }


        private void CarregarTestes()
        {
            List<Teste> listaTestes = repositorioTeste.SelecionarTodos();

            tabelaTeste.AtualizarRegistros(listaTestes);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaTeste == null)
                tabelaTeste = new TabelaTesteControl();

            CarregarTestes();

            return tabelaTeste;
        }

        public override string ObterTipoCadastro()
        {
            return "Registro de Testes";
        }

        public override void ApresentarMensagem(string mensagem, string titulo)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
