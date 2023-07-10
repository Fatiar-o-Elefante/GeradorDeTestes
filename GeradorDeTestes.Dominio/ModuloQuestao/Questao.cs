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

        public Questao(int id, Materia materia, string enunciado)
        {
            this.id = id;
            Materia = materia;
            Enunciado = enunciado;
            ListAlternativas = new List<Alternativa>();
        }

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
            List<string> erros = new List<string>();

            if (Materia == null)
                erros.Add("O campo 'Matéria' é obrigatorio");

            if (Enunciado.Length <= 5)
                erros.Add("O campo enunciado deve conter mais de 5 caracteres");

            if (string.IsNullOrEmpty(RespostaCerta))
                erros.Add("O campo  'Resposta' é obrigatorio");

            if (ListAlternativas.Count < 2)
                erros.Add("É necessário adicionar no mínimo 2 alternativas");

            if (ListAlternativas.Count > 5)
                erros.Add("O valor máximo de alternativas é 5");

            return erros.ToArray();
        }

        public void AdicionarAlternativa(Alternativa alternativa)
        {
            ListAlternativas.Add(alternativa);
        }

        public bool Existe(Alternativa alternativaParaAdicionar)
        {
            if (ListAlternativas.Exists(x => x.id == alternativaParaAdicionar.id))
                return true;

            return false;
        }

        public override string ToString()
        {
            return Enunciado;
        }
    }
}
