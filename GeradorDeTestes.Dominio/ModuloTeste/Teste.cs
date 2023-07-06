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
        public List<Questao> ListQuestoes { get; set; }

        public Teste(int id, string titulo, Disciplina disciplina, Materia materia, int quantidadeQuestoes, bool provaRecuperacao)
        {
            this.id = id;
            Titulo = titulo;
            Disciplina = disciplina;
            Materia = materia;
            QuantidadeQuestoes = quantidadeQuestoes;
            ProvaRecuperacao = provaRecuperacao;
            ListQuestoes = new List<Questao>();
        }

        public override void AtualizarInformacoes(Teste registroAtualizado)
        {
            Titulo = registroAtualizado.Titulo;
            Disciplina = registroAtualizado.Disciplina;
            Materia = registroAtualizado.Materia;
            QuantidadeQuestoes = registroAtualizado.QuantidadeQuestoes;
            ProvaRecuperacao = registroAtualizado.ProvaRecuperacao;
            ListQuestoes = registroAtualizado.ListQuestoes;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Titulo))
                erros.Add("O campo 'titulo' é obrigatorio");

            if (Disciplina == null)
                erros.Add("O campo  'disciplina' é obrigatorio");

            return erros.ToArray();
        }
    }
}
