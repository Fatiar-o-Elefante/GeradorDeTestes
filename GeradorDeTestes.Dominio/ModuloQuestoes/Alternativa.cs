using GeradorDeTestes.Dominio.Compartilhado;

namespace GeradorDeTestes.Dominio.ModuloQuestoes
{
    public class Alternativa : EntidadeBase<Alternativa>
    {
        public bool Correta { get; set; }
        public char Letra { get; set; }
        public Questao Questao { get; set; }
        public string Resposta { get; set; }

        public Alternativa(Questao questao, string resposta)
        {
            Correta = false;
            Questao = questao;
            Resposta = resposta;
            Letra = 'A';
        }

        public Alternativa(bool correta, char letra, Questao questao, string resposta)
        {
            Correta = correta;
            Letra = letra;
            Questao = questao;
            Resposta = resposta;
        }

        public override void AtualizarInformacoes(Alternativa registroAtualizado)
        {
            Correta = registroAtualizado.Correta;
            Letra = registroAtualizado.Letra;
            Questao = registroAtualizado.Questao;
            Resposta = registroAtualizado.Resposta;
        }

        public override string ToString()
        {
            return Resposta;
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }
    }
}

