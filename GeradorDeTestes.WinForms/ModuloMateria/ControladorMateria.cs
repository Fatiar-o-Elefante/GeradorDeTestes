using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloTestes;
using GeradorDeTestes.WinForms.Compartilhado;
using GeradorDeTestes.WinForms.ModuloQuestoes;
using System.Drawing.Drawing2D;

namespace GeradorDeTestes.WinForms.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;
        private TabelaMateriaControl tabelaMateria;

        public ControladorMateria(IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria)
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
        }

        public override string ToolTipInserir => "Inserir Matéria";

        public override string ToolTipEditar => "Editar Matéria";

        public override string ToolTipExcluir => "Excluir Matéria";

        public override bool VisualizarHabilitado => false;

        public override void Inserir()
        {
            TelaMateriaForm telaMateriaForm = new TelaMateriaForm(repositorioDisciplina.SelecionarTodos(), repositorioMateria.SelecionarTodos());

            DialogResult opcaoEscolhida = telaMateriaForm.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Materia materia = telaMateriaForm.ObterMateria();

                repositorioMateria.Inserir(materia);
            }

            CarregarMaterias();
        }

        public override void Editar()
        {
            TelaMateriaForm telaMateriaForm = new TelaMateriaForm(repositorioDisciplina.SelecionarTodos(), repositorioMateria.SelecionarTodos());

            Materia materiaSelecionada = ObterMateriaSelecionada();

            if (materiaSelecionada == null)
            {
                MessageBox.Show($"Selecione uma matéria primeiro!",
                    "Edição de Matérias",
                    MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            telaMateriaForm.ConfigurarTela(materiaSelecionada);

            DialogResult opcaoEscolhida = telaMateriaForm.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Materia materia = telaMateriaForm.ObterMateria();

                repositorioMateria.Editar(materia.id, materia);
            }

            CarregarMaterias();
        }


        public override void Excluir()
        {
            Materia materiaSelecionada = ObterMateriaSelecionada();

            if (materiaSelecionada == null)
            {
                MessageBox.Show($"Selecione uma matéria primeiro!",
                    "Exclusão de Matérias",
                    MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a matéria {materiaSelecionada.Nome}?", "Exclusão de Matérias",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioMateria.Excluir(materiaSelecionada);
            }

            CarregarMaterias();
        }

        private void CarregarMaterias()
        {
            List<Materia> materias = repositorioMateria.SelecionarTodos();

            tabelaMateria.AtualizarRegistros(materias);
        }

        public override void ApresentarMensagem(string mensagem, string titulo)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaMateria == null)
                tabelaMateria = new TabelaMateriaControl();

            CarregarMaterias();

            return tabelaMateria;
        }

        private Materia ObterMateriaSelecionada()
        {
            int id = tabelaMateria.ObterIdSelecionado();

            return repositorioMateria.SelecionarPorId(id);
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Matérias";
        }
    }

}
