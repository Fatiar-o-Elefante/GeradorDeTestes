namespace GeradorDeTestes.WinForms.Compartilhado
{
    public static class GridExtensions
    {
        public static void ConfigurarGridZebrado(this DataGridView grid)
        {
            Font font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

            DataGridViewCellStyle linhaEscura = new DataGridViewCellStyle
            {
                BackColor = Color.AliceBlue,
                Font = font,
                ForeColor = Color.Black,
                SelectionBackColor = Color.PowderBlue,
                SelectionForeColor = Color.Black
            };

            grid.AlternatingRowsDefaultCellStyle = linhaEscura;

            DataGridViewCellStyle linhaClara = new DataGridViewCellStyle
            {
                BackColor = Color.PowderBlue,
                Font = font,
                SelectionBackColor = Color.PowderBlue,
                SelectionForeColor = Color.Black
            };

            grid.RowsDefaultCellStyle = linhaClara;
        }

        public static void ConfigurarGridSomenteLeitura(this DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;

            grid.BorderStyle = BorderStyle.None;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            grid.MultiSelect = false;
            grid.ReadOnly = true;

            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoGenerateColumns = false;

            grid.AllowUserToResizeRows = false;
        }
    }
}
