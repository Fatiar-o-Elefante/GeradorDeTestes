namespace GeradorDeTestes.WinForms.ModuloDisciplina
{
    partial class TelaVisualizarMateriaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            listMaterias = new ListBox();
            lblDisciplina = new Label();
            label2 = new Label();
            btnCancelar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listMaterias);
            groupBox1.Location = new Point(25, 48);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(279, 260);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Matérias";
            // 
            // listMaterias
            // 
            listMaterias.FormattingEnabled = true;
            listMaterias.ItemHeight = 15;
            listMaterias.Location = new Point(6, 25);
            listMaterias.Name = "listMaterias";
            listMaterias.Size = new Size(267, 229);
            listMaterias.TabIndex = 0;
            // 
            // lblDisciplina
            // 
            lblDisciplina.AutoSize = true;
            lblDisciplina.Location = new Point(111, 29);
            lblDisciplina.Name = "lblDisciplina";
            lblDisciplina.Size = new Size(32, 15);
            lblDisciplina.TabIndex = 14;
            lblDisciplina.Text = "-----";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(25, 25);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 13;
            label2.Text = "Disciplina:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(184, 332);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(116, 37);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Fechar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // TelaVisualizarMateriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 381);
            Controls.Add(groupBox1);
            Controls.Add(lblDisciplina);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Name = "TelaVisualizarMateriaForm";
            Text = "TelaVisualizarMateriaForm";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ListBox listMaterias;
        private Label lblDisciplina;
        private Label label2;
        private Button btnCancelar;
    }
}