using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloMateria;

namespace GeradorDeTestes.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public string Nome { get; set; }
        public List<Materia> ListMaterias { get; set; }

        public Disciplina(int id, string nome)
        {
            this.id = id;
            Nome = nome;
            ListMaterias = new List<Materia>();
        }

        public override void AtualizarInformacoes(Disciplina registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }
    }
}
