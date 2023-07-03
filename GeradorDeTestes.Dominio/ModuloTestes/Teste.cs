using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestoes;

namespace GeradorDeTestes.Dominio.ModuloTestes
{
    public class Teste : EntidadeBase<Teste>
    {
        public string Titulo { get; set; }
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }
        public int QuantidadeQuestoes { get; set; }
        public bool ProvaRecuperacao { get; set; }
        public List<Questoes> ListQuestoes { get; set; }

        public Teste(string titulo, Disciplina disciplina, Materia materia, int quantidadeQuestoes, bool provaRecuperacao, List<Questoes> listQuestoes)
        {
            Titulo = titulo;
            Disciplina = disciplina;
            Materia = materia;
            QuantidadeQuestoes = quantidadeQuestoes;
            ProvaRecuperacao = provaRecuperacao;
            ListQuestoes = listQuestoes;
        }

        public override void AtualizarInformacoes(Teste registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }
    }
}
