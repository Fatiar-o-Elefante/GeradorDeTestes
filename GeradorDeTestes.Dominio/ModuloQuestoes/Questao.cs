using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloMateria;

namespace GeradorDeTestes.Dominio.ModuloQuestoes
{
    public class Questao : EntidadeBase<Questao>
    {
        public Materia Materia { get; set; }
        public string Enunciado { get; set; }
        public string RespostaCerta { get; set; }
        public List<Alternativa> ListAlternativas { get; set; }

        public Questao(int id, Materia materia, string enunciado, string respostaCerta)
        {
            this.id = id;
            Materia = materia;
            Enunciado = enunciado;
            RespostaCerta = respostaCerta;
            ListAlternativas = new List<Alternativa>();
        }

        public override void AtualizarInformacoes(Questao registroAtualizado)
        {
            Materia = registroAtualizado.Materia;
            Enunciado = registroAtualizado.Enunciado;
            RespostaCerta = registroAtualizado.RespostaCerta;
            ListAlternativas = registroAtualizado.ListAlternativas;
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }

        public void AdicionarAlternativa(Alternativa alternativa)
        {
            ListAlternativas.Add(alternativa);
        }

        public bool Contem(Alternativa alternativaParaAdicionar)
        {
            if (ListAlternativas.Contains(alternativaParaAdicionar))
                return true;

            return false;
        }

        public void RemoverAlternativa(Alternativa alternaticaParaRemover)
        {
            ListAlternativas.Remove(alternaticaParaRemover);
        }
    }
}
