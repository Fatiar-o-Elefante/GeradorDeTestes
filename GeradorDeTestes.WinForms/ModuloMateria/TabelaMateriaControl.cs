using GeradorDeTestes.Dominio.ModuloMateria;

namespace GeradorDeTestes.WinForms.ModuloMateria
{
    public partial class TabelaMateriaControl : UserControl
    {
        public TabelaMateriaControl()
        {
            InitializeComponent();
        }

        public int ObterIdSelecionado()
        {
            int id;

            try
            {
                id = Convert.ToInt32(grid.SelectedRows[0].Cells["id"].Value);
            }
            catch
            {
                id = -1;
            }

            return id;
        }

        public void AtualizarRegistros(List<Materia> listaMaterias)
        {
            grid.Rows.Clear();
            foreach (Materia materia in listaMaterias)
            {
                grid.Rows.Add(materia.id, materia.Nome, materia.Disciplina, materia.Serie);
            }
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {listaMaterias.Count} cliente(s)");
        }
    }
}
