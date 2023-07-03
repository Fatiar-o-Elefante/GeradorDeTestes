using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloDisciplina;

namespace GeradorDeTestes.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string Nome { get; set; }
        public Disciplina Disciplina { get; set; }
        public SerieEnum Serie { get; set; }

        public Materia(int id, string nome, Disciplina disciplina, int serie)
        {
            this.id = id;
            Nome = nome;
            Disciplina = disciplina;
            Serie = serie;
        }

        public override void AtualizarInformacoes(Materia registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }
    }
}
