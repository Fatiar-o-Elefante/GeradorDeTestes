using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloDisciplina;

namespace GeradorDeTestes.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string Nome { get; set; }
        public Disciplina Disciplina { get; set; }
        public SerieEnum Serie { get; set; }

        public Materia(int id, string nome, Disciplina disciplina, SerieEnum serie)
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

            if (Nome.Length < 3)
                erros.Add("O campo 'Nome' deve conter no mínimo 3 caracteres");

            return erros.ToArray();
        }
    }
}
