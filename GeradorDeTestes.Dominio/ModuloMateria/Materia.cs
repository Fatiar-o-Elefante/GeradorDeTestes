using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloDisciplina;

namespace GeradorDeTestes.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string Nome { get; set; }
        public Disciplina Disciplina { get; set; }
        public int Serie { get; set; }

        public Materia(int id, string nome, int serie)
        {
            this.id = id;
            Nome = nome;
            Serie = serie;
        }

        public Materia(int id, string nome, Disciplina disciplina, int serie)
        {
            this.id = id;
            Nome = nome;
            Disciplina = disciplina;
            Serie = serie;
        }

        public override void AtualizarInformacoes(Materia registroAtualizado)
        {
            Nome = registroAtualizado.Nome;
            Disciplina = registroAtualizado.Disciplina;
            Serie = registroAtualizado.Serie;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O campo 'nome' é obrigatorio");

            if (Nome.Length <= 5)
                erros.Add("O campo nome deve conter mais de 5 caracteres");

            if (Disciplina == null)
                erros.Add("O campo  'disciplina' é obrigatorio");

            if (Serie == 0)
                erros.Add("O campo 'série' é obrigatório");

            return erros.ToArray();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
