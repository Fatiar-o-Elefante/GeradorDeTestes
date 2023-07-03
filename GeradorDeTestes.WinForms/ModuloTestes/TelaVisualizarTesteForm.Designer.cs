namespace GeradorDeTestes.WinForms.ModuloTestes
{
    partial class TelaVisualizarTesteForm
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
            btnFechar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblTitulo = new Label();
            lblDisciplina = new Label();
            lblMateria = new Label();
            groupBox1 = new GroupBox();
            listBoxQuestoes = new ListBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnFechar
            // 
            btnFechar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFechar.DialogResult = DialogResult.Cancel;
            btnFechar.Location = new Point(266, 355);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(87, 37);
            btnFechar.TabIndex = 10;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 26);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 11;
            label1.Text = "Título";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 58);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 12;
            label2.Text = "Disciplina";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 89);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 13;
            label3.Text = "Matéria";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(82, 26);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(72, 15);
            lblTitulo.TabIndex = 14;
            lblTitulo.Text = "-------------";
            // 
            // lblDisciplina
            // 
            lblDisciplina.AutoSize = true;
            lblDisciplina.Location = new Point(82, 58);
            lblDisciplina.Name = "lblDisciplina";
            lblDisciplina.Size = new Size(72, 15);
            lblDisciplina.TabIndex = 15;
            lblDisciplina.Text = "-------------";
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Location = new Point(82, 89);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(72, 15);
            lblMateria.TabIndex = 16;
            lblMateria.Text = "-------------";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBoxQuestoes);
            groupBox1.Location = new Point(18, 121);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(335, 228);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Questões Selecionadas";
            // 
            // listBoxQuestoes
            // 
            listBoxQuestoes.FormattingEnabled = true;
            listBoxQuestoes.ItemHeight = 15;
            listBoxQuestoes.Location = new Point(11, 22);
            listBoxQuestoes.Name = "listBoxQuestoes";
            listBoxQuestoes.Size = new Size(318, 199);
            listBoxQuestoes.TabIndex = 0;
            // 
            // TelaVisualizarTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 404);
            Controls.Add(groupBox1);
            Controls.Add(lblMateria);
            Controls.Add(lblDisciplina);
            Controls.Add(lblTitulo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnFechar);
            Name = "TelaVisualizarTesteForm";
            Text = "Visualizar Testes";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFechar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblTitulo;
        private Label lblDisciplina;
        private Label lblMateria;
        private GroupBox groupBox1;
        private ListBox listBoxQuestoes;
    }
}