using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.WinForms.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract string ToolTipInserir { get; }

        public abstract string ToolTipEditar { get; }

        public abstract string ToolTipExcluir { get; }

        public virtual string ToolTipVisualizar { get; }

        public virtual string ToolTipDuplicar { get; }

        public virtual string ToolTipSalvar { get; }

        public virtual bool InserirHabilitado { get { return true; } }

        public virtual bool EditarHabilitado { get { return true; } }

        public virtual bool ExcluirHabilitado { get { return true; } }

        public virtual bool VisualizarHabilitado { get { return false; } }

        public virtual bool DuplicarHabilitado { get { return false; } }

        public virtual bool SalvarHabilitado { get { return false; } }

        public abstract void Inserir();

        public abstract void Editar();

        public abstract void Excluir();

        public virtual void Visualizar(){}

        public virtual void Duplicar(){}

        public virtual void Salvar(){}

        public abstract void ApresentarMensagem(string mensagem, string titulo);

        public abstract UserControl ObterListagem();

        public abstract string ObterTipoCadastro();
    }
}
