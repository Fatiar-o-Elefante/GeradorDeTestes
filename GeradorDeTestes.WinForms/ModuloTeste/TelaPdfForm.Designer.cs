namespace GeradorDeTestes.WinForms.ModuloTeste
{
    partial class TelaPdfForm
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
            label1 = new Label();
            rdbGabarito = new RadioButton();
            rdbQuestao = new RadioButton();
            txtDiretorio = new TextBox();
            btnDiretorio = new Button();
            btnGerar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(100, 21);
            label1.TabIndex = 0;
            label1.Text = "Opções PDF";
            // 
            // rdbGabarito
            // 
            rdbGabarito.AutoSize = true;
            rdbGabarito.Location = new Point(12, 47);
            rdbGabarito.Name = "rdbGabarito";
            rdbGabarito.Size = new Size(70, 19);
            rdbGabarito.TabIndex = 1;
            rdbGabarito.TabStop = true;
            rdbGabarito.Text = "Gabarito";
            rdbGabarito.UseVisualStyleBackColor = true;
            // 
            // rdbQuestao
            // 
            rdbQuestao.AutoSize = true;
            rdbQuestao.Location = new Point(12, 72);
            rdbQuestao.Name = "rdbQuestao";
            rdbQuestao.Size = new Size(116, 19);
            rdbQuestao.TabIndex = 2;
            rdbQuestao.TabStop = true;
            rdbQuestao.Text = "Apenas Questões";
            rdbQuestao.UseVisualStyleBackColor = true;
            // 
            // txtDiretorio
            // 
            txtDiretorio.Location = new Point(12, 155);
            txtDiretorio.Name = "txtDiretorio";
            txtDiretorio.Size = new Size(352, 23);
            txtDiretorio.TabIndex = 3;
            // 
            // btnDiretorio
            // 
            btnDiretorio.Location = new Point(12, 118);
            btnDiretorio.Name = "btnDiretorio";
            btnDiretorio.Size = new Size(352, 31);
            btnDiretorio.TabIndex = 4;
            btnDiretorio.Text = "Diretório";
            btnDiretorio.UseVisualStyleBackColor = true;
            btnDiretorio.Click += btnDiretorio_Click_1;
            // 
            // btnGerar
            // 
            btnGerar.Location = new Point(183, 197);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(89, 40);
            btnGerar.TabIndex = 5;
            btnGerar.Text = "Elaborar PDF";
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Click += btnGerar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(278, 197);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 40);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaPdfForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 257);
            Controls.Add(btnCancelar);
            Controls.Add(btnGerar);
            Controls.Add(btnDiretorio);
            Controls.Add(txtDiretorio);
            Controls.Add(rdbQuestao);
            Controls.Add(rdbGabarito);
            Controls.Add(label1);
            Name = "TelaPdfForm";
            Text = "TelaPdfForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton rdbGabarito;
        private RadioButton rdbQuestao;
        private TextBox txtDiretorio;
        private Button btnDiretorio;
        private Button btnGerar;
        private Button btnCancelar;
    }
}