using GeradorDeTestes.WinForms.Compartilhado;
using GeradorDeTestes.WinForms.ModuloDisciplina;
using GeradorDeTestes.WinForms.ModuloQuestoes;
using GeradorDeTestes.WinForms.ModuloTestes;

namespace GeradorDeTestes.WinForms
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;

        private static TelaPrincipalForm telaPrincipal;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            telaPrincipal = this;
        }

        public void AtualizarRodape(string mensagem)
        {
            lblStatus.Text = mensagem;
        }

        public static TelaPrincipalForm Instancia
        {
            get
            {
                if (telaPrincipal == null)
                    telaPrincipal = new TelaPrincipalForm();

                return telaPrincipal;
            }
        }

        private void ConfigurarTelaPrincipal(ControladorBase controladorBase)
        {
            lblTipoCadastro.Text = controladorBase.ObterTipoCadastro();

            ConfigurarBarraFerramentas(controlador);

            ConfigurarListagem(controlador);
        }

        private void ConfigurarListagem(ControladorBase controladorBase)
        {
            UserControl listagem = controladorBase.ObterListagem();

            listagem.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(listagem);
        }

        private void ConfigurarBarraFerramentas(ControladorBase controlador)
        {
            barraFerramentas.Enabled = true;

            ConfigurarToolTips(controlador);

            ConfigurarEstados(controlador);
        }

        private void ConfigurarEstados(ControladorBase controlador)
        {
            btnInserir.Enabled = controlador.InserirHabilitado;
            btnEditar.Enabled = controlador.EditarHabilitado;
            btnExcluir.Enabled = controlador.ExcluirHabilitado;
            btnVisualizar.Enabled = controlador.VisualizarHabilitado;
            //btnDuplicar.Enabled = controlador.DuplicarHabilitado;
            //btnSalvar.Enabled = controlador.SalvarHabilitado;
        }

        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btnInserir.ToolTipText = controlador.ToolTipInserir;
            btnEditar.ToolTipText = controlador.ToolTipEditar;
            btnExcluir.ToolTipText = controlador.ToolTipExcluir;
            btnVisualizar.ToolTipText = controlador.ToolTipVisualizar;
            //btnDuplicar.ToolTipText = controlador.ToolTipDuplicar;
            //btnSalvar.ToolTipText = controlador.ToolTipSalvar;
        }

        private void materiaMenuItem_Click(object sender, EventArgs e)
        {
            //controlador = new ControladorMateria();

            ConfigurarTelaPrincipal(controlador);
        }

        private void disciplinaMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorDisciplina();

            ConfigurarTelaPrincipal(controlador);
        }

        private void questoesMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorQuestoes();

            ConfigurarTelaPrincipal(controlador);
        }

        private void testesMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorTeste();

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            controlador.Visualizar();
        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            //controlador.Duplicar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //controlador.Salvar();
        }
    }
}