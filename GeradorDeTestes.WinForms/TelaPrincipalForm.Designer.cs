﻿namespace GeradorDeTestes.WinForms
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipalForm));
            menuBar = new MenuStrip();
            cadastroMenu = new ToolStripMenuItem();
            materiaToolStripMenuItem = new ToolStripMenuItem();
            materiaMenuItem = new ToolStripMenuItem();
            disciplinaMenuItem = new ToolStripMenuItem();
            questoesMenuItem = new ToolStripMenuItem();
            testesMenuItem = new ToolStripMenuItem();
            barraFerramentas = new ToolStrip();
            btnInserir = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDuplicar = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnVisualizar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnSalvar = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            lblTipoCadastro = new ToolStripLabel();
            panelRegistros = new Panel();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            menuBar.SuspendLayout();
            barraFerramentas.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuBar
            // 
            menuBar.BackColor = Color.LightSteelBlue;
            menuBar.ImageScalingSize = new Size(28, 28);
            menuBar.Items.AddRange(new ToolStripItem[] { cadastroMenu });
            menuBar.Location = new Point(0, 0);
            menuBar.Name = "menuBar";
            menuBar.Padding = new Padding(4, 1, 0, 1);
            menuBar.Size = new Size(624, 34);
            menuBar.TabIndex = 0;
            menuBar.Text = "menuStrip1";
            // 
            // cadastroMenu
            // 
            cadastroMenu.DropDownItems.AddRange(new ToolStripItem[] { materiaToolStripMenuItem, questoesMenuItem, testesMenuItem });
            cadastroMenu.Image = (Image)resources.GetObject("cadastroMenu.Image");
            cadastroMenu.Name = "cadastroMenu";
            cadastroMenu.Size = new Size(99, 32);
            cadastroMenu.Text = "Cadastros";
            // 
            // materiaToolStripMenuItem
            // 
            materiaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { materiaMenuItem, disciplinaMenuItem });
            materiaToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            materiaToolStripMenuItem.Name = "materiaToolStripMenuItem";
            materiaToolStripMenuItem.Size = new Size(123, 22);
            materiaToolStripMenuItem.Text = "Matéria";
            // 
            // materiaMenuItem
            // 
            materiaMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            materiaMenuItem.Name = "materiaMenuItem";
            materiaMenuItem.Size = new Size(125, 22);
            materiaMenuItem.Text = "Matéria";
            materiaMenuItem.Click += materiaMenuItem_Click_1;
            // 
            // disciplinaMenuItem
            // 
            disciplinaMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            disciplinaMenuItem.Name = "disciplinaMenuItem";
            disciplinaMenuItem.Size = new Size(125, 22);
            disciplinaMenuItem.Text = "Disciplina";
            disciplinaMenuItem.Click += disciplinaMenuItem_Click_1;
            // 
            // questoesMenuItem
            // 
            questoesMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            questoesMenuItem.Name = "questoesMenuItem";
            questoesMenuItem.Size = new Size(123, 22);
            questoesMenuItem.Text = "Questões";
            questoesMenuItem.Click += questoesMenuItem_Click_1;
            // 
            // testesMenuItem
            // 
            testesMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            testesMenuItem.Name = "testesMenuItem";
            testesMenuItem.Size = new Size(123, 22);
            testesMenuItem.Text = "Testes";
            testesMenuItem.Click += testesMenuItem_Click_1;
            // 
            // barraFerramentas
            // 
            barraFerramentas.BackColor = Color.White;
            barraFerramentas.ImageScalingSize = new Size(28, 28);
            barraFerramentas.Items.AddRange(new ToolStripItem[] { btnInserir, btnEditar, btnExcluir, toolStripSeparator1, btnDuplicar, toolStripSeparator3, btnVisualizar, toolStripSeparator2, btnSalvar, toolStripSeparator5, lblTipoCadastro });
            barraFerramentas.Location = new Point(0, 34);
            barraFerramentas.Name = "barraFerramentas";
            barraFerramentas.Size = new Size(624, 49);
            barraFerramentas.TabIndex = 1;
            barraFerramentas.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            btnInserir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnInserir.Enabled = false;
            btnInserir.Image = (Image)resources.GetObject("btnInserir.Image");
            btnInserir.ImageTransparentColor = Color.Transparent;
            btnInserir.Name = "btnInserir";
            btnInserir.Padding = new Padding(7);
            btnInserir.Size = new Size(46, 46);
            btnInserir.Text = "toolStripButton1";
            btnInserir.ToolTipText = "\r\n";
            btnInserir.Click += btnInserir_Click_1;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Enabled = false;
            btnEditar.Image = (Image)resources.GetObject("btnEditar.Image");
            btnEditar.ImageTransparentColor = Color.Transparent;
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new Padding(7);
            btnEditar.Size = new Size(46, 46);
            btnEditar.Text = "toolStripButton3";
            btnEditar.ToolTipText = "\r\n";
            btnEditar.Click += btnEditar_Click_1;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExcluir.Enabled = false;
            btnExcluir.Image = (Image)resources.GetObject("btnExcluir.Image");
            btnExcluir.ImageTransparentColor = Color.Transparent;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new Padding(7);
            btnExcluir.Size = new Size(46, 46);
            btnExcluir.Text = "toolStripButton2";
            btnExcluir.ToolTipText = "\r\n";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Padding = new Padding(7);
            toolStripSeparator1.Size = new Size(6, 49);
            // 
            // btnDuplicar
            // 
            btnDuplicar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDuplicar.Enabled = false;
            btnDuplicar.Image = (Image)resources.GetObject("btnDuplicar.Image");
            btnDuplicar.ImageTransparentColor = Color.Transparent;
            btnDuplicar.Name = "btnDuplicar";
            btnDuplicar.Padding = new Padding(7);
            btnDuplicar.Size = new Size(46, 46);
            btnDuplicar.Text = "toolStripButton4";
            btnDuplicar.ToolTipText = "\r\n";
            btnDuplicar.Click += btnDuplicar_Click_1;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Padding = new Padding(7);
            toolStripSeparator3.Size = new Size(6, 49);
            // 
            // btnVisualizar
            // 
            btnVisualizar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnVisualizar.Enabled = false;
            btnVisualizar.Image = (Image)resources.GetObject("btnVisualizar.Image");
            btnVisualizar.ImageTransparentColor = Color.Transparent;
            btnVisualizar.Name = "btnVisualizar";
            btnVisualizar.Padding = new Padding(7);
            btnVisualizar.Size = new Size(46, 46);
            btnVisualizar.Text = "toolStripButton4";
            btnVisualizar.ToolTipText = "\r\n";
            btnVisualizar.Click += btnVisualizar_Click_1;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Padding = new Padding(7);
            toolStripSeparator2.Size = new Size(6, 49);
            // 
            // btnSalvar
            // 
            btnSalvar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSalvar.Enabled = false;
            btnSalvar.Image = (Image)resources.GetObject("btnSalvar.Image");
            btnSalvar.ImageTransparentColor = Color.Transparent;
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Padding = new Padding(7);
            btnSalvar.Size = new Size(46, 46);
            btnSalvar.Text = "toolStripButton4";
            btnSalvar.ToolTipText = "\r\n";
            btnSalvar.Click += btnSalvar_Click_1;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Padding = new Padding(7);
            toolStripSeparator5.Size = new Size(6, 49);
            // 
            // lblTipoCadastro
            // 
            lblTipoCadastro.Name = "lblTipoCadastro";
            lblTipoCadastro.Size = new Size(77, 46);
            lblTipoCadastro.Text = "TipoCadastro";
            // 
            // panelRegistros
            // 
            panelRegistros.BackColor = Color.Transparent;
            panelRegistros.Dock = DockStyle.Fill;
            panelRegistros.Location = new Point(0, 83);
            panelRegistros.Margin = new Padding(2);
            panelRegistros.Name = "panelRegistros";
            panelRegistros.Size = new Size(624, 285);
            panelRegistros.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(28, 28);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 346);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 8, 0);
            statusStrip1.Size = new Size(624, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(198, 17);
            lblStatus.Text = "Bem-vindo (a) ao Gerador de Provas";
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 368);
            Controls.Add(statusStrip1);
            Controls.Add(panelRegistros);
            Controls.Add(barraFerramentas);
            Controls.Add(menuBar);
            MainMenuStrip = menuBar;
            Margin = new Padding(2);
            Name = "TelaPrincipalForm";
            ShowIcon = false;
            Text = "Gerador de Testes";
            menuBar.ResumeLayout(false);
            menuBar.PerformLayout();
            barraFerramentas.ResumeLayout(false);
            barraFerramentas.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuBar;
        private ToolStripMenuItem cadastroMenu;
        private ToolStripMenuItem materiaToolStripMenuItem;
        private ToolStripMenuItem materiaMenuItem;
        private ToolStripMenuItem disciplinaMenuItem;
        private ToolStripMenuItem questoesMenuItem;
        private ToolStripMenuItem testesMenuItem;
        private ToolStrip barraFerramentas;
        private ToolStripButton btnInserir;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnVisualizar;
        private ToolStripLabel lblTipoCadastro;
        private Panel panelRegistros;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripButton btnDuplicar;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnSalvar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator5;
    }
}