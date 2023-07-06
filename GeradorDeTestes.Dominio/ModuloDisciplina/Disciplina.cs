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
            Nome = registroAtualizado.Nome;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O campo 'nome' é obrigatorio");

            if (Nome.Length <= 5)
                erros.Add("O campo nome deve conter mais de 5 caracteres");

            return erros.ToArray();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
