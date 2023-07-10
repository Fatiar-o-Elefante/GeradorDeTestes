using GeradorDeTestes.Dominio.ModuloTestes;
using GeradorDeTestes.WinForms.Compartilhado;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorDeTestes.Dominio.ModuloQuestoes;

namespace GeradorDeTestes.WinForms.ModuloTeste
{
    public partial class TelaPdfForm : Form
    {
        private Teste testeSelecionado;
        private IRepositorioQuestao repositorioQuestao;

        public TelaPdfForm(Teste testeSelecionado, IRepositorioQuestao repositorioQuestao)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            this.testeSelecionado = testeSelecionado;
            this.repositorioQuestao = repositorioQuestao;
        }

        private string DefinirNomeArquivo()
        {
            if (rdbQuestao.Checked)
                return $"{testeSelecionado.Titulo} - Questões";

            else return $"{testeSelecionado.Titulo} - Gabarito";
        }

        private void btnDiretorio_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtDiretorio.Text = fbd.SelectedPath;
            }

            DialogResult = DialogResult.None;
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtDiretorio.Text))
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Escolha um diretório para guardar seu PDF");
                DialogResult = DialogResult.None;
                return false;
            }

            if (!rdbQuestao.Checked && !rdbGabarito.Checked)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Escolha qual opção de PDF à ser gerado");
                DialogResult = DialogResult.None;
                return false;
            }

            return true;
        }

        private void btnGerar_Click_1(object sender, EventArgs e)
        {
            if (Validar())
            {
                EscreverPdf();
                MessageBox.Show($"PDF gerado com sucesso! Confira no caminho: \n{txtDiretorio.Text}");
            }
        }

        private void EscreverPdf()
        {
            string nomePdf = DefinirNomeArquivo();

            string caminho = Path.Combine(txtDiretorio.Text, nomePdf + ".pdf");

            Document doc = new Document(PageSize.A4, 20, 20, 10, 10);
            FileStream fs = new FileStream(caminho, FileMode.Create, FileAccess.Write, FileShare.None);

            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            //-------------------------------------------------------------------------------------------------------------------------------------------
            doc.Open();

            BaseColor corPadrao = BaseColor.BLACK;
            BaseColor corGabarito = new BaseColor(34, 139, 34);

            iTextSharp.text.Font fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, corPadrao);
            iTextSharp.text.Font fonteInfo = FontFactory.GetFont(FontFactory.HELVETICA, 13, corPadrao);
            iTextSharp.text.Font fonteQuestao = FontFactory.GetFont(FontFactory.HELVETICA, 12, corPadrao);
            iTextSharp.text.Font fonteGabarito = FontFactory.GetFont(FontFactory.HELVETICA, 12, corGabarito);

            Paragraph data = new Paragraph(string.Format($"Data: {DateTime.Today.ToString("dd/MM/yyyy")}"), fonteInfo);
            doc.Add(data);

            //if (!string.IsNullOrEmpty(txtNome.Text))
            //{
            //    Paragraph nomeEstudante = new Paragraph(string.Format($"Nome: {txtNome.Text}"), fonteInfo);
            //    doc.Add(nomeEstudante);
            //}

            Paragraph disciplina = new Paragraph(string.Format($"Disciplina: {testeSelecionado.Disciplina}"), fonteInfo);
            doc.Add(disciplina);

            Paragraph materia = new Paragraph(string.Format($"Matéria: {testeSelecionado.Materia}, {testeSelecionado.Materia.Serie}"), fonteInfo);
            doc.Add(materia);

            if (testeSelecionado.ProvaRecuperacao)
            {
                Paragraph recuperacao = new Paragraph(string.Format($"Prova de recuperação"), fonteInfo);
                doc.Add(recuperacao);
            }

            doc.Add(new Paragraph(" "));

            Paragraph titulo = new Paragraph(string.Format($"{testeSelecionado.Titulo.ToUpper()}"), fonteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);

            doc.Add(new Paragraph(" "));

            testeSelecionado.ListQuestoes.ForEach(q =>
            {
                char letra = 'A';
                repositorioQuestao.CarregarAlternativas(q);

                Paragraph questao = new Paragraph(string.Format($"{q}"), fonteQuestao);
                doc.Add(questao);
                doc.Add(new Paragraph(" "));

                q.ListaAlternativas.ForEach(a =>
                {
                    Paragraph alternativa = new Paragraph(string.Format($"{letra}) {a}"), fonteQuestao);
                    doc.Add(alternativa);
                    doc.Add(new Paragraph(" "));
                    letra++;
                });

                if (rdbGabarito.Checked)
                {
                    Paragraph respostaCerta = new Paragraph(string.Format($"Resposta Certa: {q.RespostaCerta}"), fonteGabarito);
                    doc.Add(respostaCerta);
                    doc.Add(new Paragraph(" "));
                }
            });

            doc.Close();
            //-------------------------------------------------------------------------------------------------------------------------------------------
        }


    }
}
