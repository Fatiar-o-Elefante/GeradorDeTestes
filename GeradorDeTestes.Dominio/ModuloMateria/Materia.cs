using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloDisciplina;

namespace GeradorDeTestes.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string Nome { get; set; }
        public Disciplina Disciplina { get; set; }
        public int Serie { get; set; }

        public Materia(int id, string nome, Disciplina disciplina, int serie)
        {
            this.id = id;
            Nome = nome;
            Disciplina = disciplina;
            Serie = serie;
        }

        public override void AtualizarInformacoes(Materia registroAtualizado)
        {
            this.id += registroAtualizado.id;
            this.Nome = registroAtualizado.Nome;
            this.Disciplina = registroAtualizado.Disciplina;
            this.Serie = registroAtualizado.Serie;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O campo 'Nome' é obrigatório");

            if (Nome.Length < 4)
                erros.Add("O campo 'Nome' deve conter no mínimo 4 caracteres");

            if (Disciplina == null)
                erros.Add("O campo 'Disciplina' é obrigatório");

            if (Serie == 0)
                erros.Add("O campo 'Serie' é obrigatório");

            return erros.ToArray();
        }
    }
}
