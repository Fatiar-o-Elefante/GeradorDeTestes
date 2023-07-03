namespace GeradorDeTestes.WinForms.ModuloTestes
{
    partial class TelaTesteForm
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
            txtId = new TextBox();
            label1 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            label2 = new Label();
            cbDisciplina = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            numQtdQuestoes = new NumericUpDown();
            txtTitulo = new TextBox();
            label5 = new Label();
            cbMateria = new ComboBox();
            chProvaRecup = new CheckBox();
            groupBox1 = new GroupBox();
            btnSortear = new Button();
            listBoxSorteadas = new ListBox();
            ((System.ComponentModel.ISupportInitialize)numQtdQuestoes).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(343, 27);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(19, 23);
            txtId.TabIndex = 12;
            txtId.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(320, 30);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 11;
            label1.Text = "id";
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(184, 336);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(87, 37);
            btnGravar.TabIndex = 10;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(277, 336);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(87, 37);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 30);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 13;
            label2.Text = "Título";
            // 
            // cbDisciplina
            // 
            cbDisciplina.FormattingEnabled = true;
            cbDisciplina.Location = new Point(76, 71);
            cbDisciplina.Name = "cbDisciplina";
            cbDisciplina.Size = new Size(134, 23);
            cbDisciplina.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 74);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 15;
            label3.Text = "Disciplina";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(228, 74);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 16;
            label4.Text = "Qtd. Questões";
            // 
            // numQtdQuestoes
            // 
            numQtdQuestoes.Location = new Point(316, 71);
            numQtdQuestoes.Name = "numQtdQuestoes";
            numQtdQuestoes.Size = new Size(46, 23);
            numQtdQuestoes.TabIndex = 17;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(76, 27);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(226, 23);
            txtTitulo.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 116);
            label5.Name = "label5";
            label5.Size = new Size(47, 15);
            label5.TabIndex = 19;
            label5.Text = "Matéria";
            // 
            // cbMateria
            // 
            cbMateria.FormattingEnabled = true;
            cbMateria.Location = new Point(76, 113);
            cbMateria.Name = "cbMateria";
            cbMateria.Size = new Size(134, 23);
            cbMateria.TabIndex = 20;
            // 
            // chProvaRecup
            // 
            chProvaRecup.AutoSize = true;
            chProvaRecup.Location = new Point(219, 115);
            chProvaRecup.Name = "chProvaRecup";
            chProvaRecup.Size = new Size(143, 19);
            chProvaRecup.TabIndex = 21;
            chProvaRecup.Text = "Prova de Recuperação";
            chProvaRecup.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBoxSorteadas);
            groupBox1.Controls.Add(btnSortear);
            groupBox1.Location = new Point(12, 142);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(350, 188);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Questões Selecionadas";
            // 
            // btnSortear
            // 
            btnSortear.Location = new Point(6, 22);
            btnSortear.Name = "btnSortear";
            btnSortear.Size = new Size(75, 23);
            btnSortear.TabIndex = 0;
            btnSortear.Text = "Sortear";
            btnSortear.UseVisualStyleBackColor = true;
            // 
            // listBoxSorteadas
            // 
            listBoxSorteadas.FormattingEnabled = true;
            listBoxSorteadas.ItemHeight = 15;
            listBoxSorteadas.Location = new Point(6, 51);
            listBoxSorteadas.Name = "listBoxSorteadas";
            listBoxSorteadas.Size = new Size(338, 124);
            listBoxSorteadas.TabIndex = 1;
            // 
            // TelaTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 385);
            Controls.Add(groupBox1);
            Controls.Add(chProvaRecup);
            Controls.Add(cbMateria);
            Controls.Add(label5);
            Controls.Add(txtTitulo);
            Controls.Add(numQtdQuestoes);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbDisciplina);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Name = "TelaTesteForm";
            Text = "Cadastro de Testes";
            ((System.ComponentModel.ISupportInitialize)numQtdQuestoes).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private Label label1;
        private Button btnGravar;
        private Button btnCancelar;
        private Label label2;
        private ComboBox cbDisciplina;
        private Label label3;
        private Label label4;
        private NumericUpDown numQtdQuestoes;
        private TextBox txtTitulo;
        private Label label5;
        private ComboBox cbMateria;
        private CheckBox chProvaRecup;
        private GroupBox groupBox1;
        private ListBox listBoxSorteadas;
        private Button btnSortear;
    }
}