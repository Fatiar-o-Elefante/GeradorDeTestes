using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestoes;
using GeradorDeTestes.WinForms.Compartilhado;
using GeradorDeTestes.WinForms.ModuloQuestoes;

namespace GeradorDeTestes.WinForms.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private TabelaDisciplinaControl tabelaDisciplina;

        public ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override string ToolTipInserir => "Inserir Disciplina";

        public override string ToolTipEditar => "Editar Disciplina";

        public override string ToolTipExcluir => "Excluir Disciplina";

        public override string ToolTipVisualizar => "Visualizar Matérias da Disciplina";

        public override void Inserir()
        {
            TelaDisciplinaForm telaDisciplina = new TelaDisciplinaForm(repositorioDisciplina.SelecionarTodos());

            DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Disciplina disciplina = telaDisciplina.ObterDisciplina();

                repositorioDisciplina.Inserir(disciplina);

                CarregarDisciplina();
            }
        }

        public override void Editar()
        {
            Disciplina disciplinaSelecionada = ObterDisciplinaSelecionada();

            if (disciplinaSelecionada == null)
            {
                ApresentarMensagem("Selecione uma disciplina primeiro!", "Edição de Disciplinas");
                return;
            }

            TelaDisciplinaForm telaDisciplina = new TelaDisciplinaForm(repositorioDisciplina.SelecionarTodos());
            telaDisciplina.ConfigurarTela(disciplinaSelecionada);

            DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Disciplina disciplina = telaDisciplina.ObterDisciplina();

                foreach (Disciplina d in repositorioDisciplina.SelecionarTodos())
                {
                    if (disciplina.Nome == d.Nome)
                    {
                        TelaPrincipalForm.Instancia.AtualizarRodape("O nome já está em uso");
                        telaDisciplina.ShowDialog();
                        return;
                    }
                }

                repositorioDisciplina.Editar(disciplina.id, disciplina);

                CarregarDisciplina();
            }
        }

        public override void Excluir()
        {
            Disciplina disciplina = ObterDisciplinaSelecionada();

            if (disciplina == null)
            {
                ApresentarMensagem("Selecione um disciplina primeiro!", "Exclusão de Disciplinas");
                return;
            }


            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o disciplina {disciplina.Nome}?", "Exclusão de Disciplinas",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                if (disciplina.ListMaterias.Count > 0)
                {
                    MessageBox.Show("Exclusão inválida, disciplina possui materiais");
                    return;
                }

                try
                {
                    repositorioDisciplina.Excluir(disciplina);
                }
                catch (Microsoft.Data.SqlClient.SqlException)
                {
                    ApresentarMensagem("Não é possível excluir a disciplina pois ela possui uma materia!", "Exclusão de Disciplina");
                }
            }

            CarregarDisciplina();
        }        

        private Disciplina ObterDisciplinaSelecionada()
        {
            int id = tabelaDisciplina.ObterIdSelecionado();

            return repositorioDisciplina.SelecionarPorId(id);
        }

        private void CarregarDisciplina()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            tabelaDisciplina.AtualizarRegistros(disciplinas);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaDisciplina == null)
                tabelaDisciplina = new TabelaDisciplinaControl();

            CarregarDisciplina();

            return tabelaDisciplina;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Disciplina";
        }

        public override void ApresentarMensagem(string mensagem, string titulo)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}
