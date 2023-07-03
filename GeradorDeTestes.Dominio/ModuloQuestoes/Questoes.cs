using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloMateria;

namespace GeradorDeTestes.Dominio.ModuloQuestoes
{
    public class Questoes : EntidadeBase<Questoes>
    {
        public Materia Materia { get; set; }
        public string Enunciado { get; set; }
        public string RespostaCerta { get; set; }
        public List<string> ListAlternativas { get; set; }

        public Questoes(Materia materia, string enunciado, string respostaCerta, List<string> listAlternativas)
        {
            Materia = materia;
            Enunciado = enunciado;
            RespostaCerta = respostaCerta;
            ListAlternativas = listAlternativas;
        }

        public override void AtualizarInformacoes(Questoes registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }
    }
}
