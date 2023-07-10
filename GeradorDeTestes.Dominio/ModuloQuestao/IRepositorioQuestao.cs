using GeradorDeTestes.Dominio.Compartilhado;

namespace GeradorDeTestes.Dominio.ModuloQuestoes
{
    public interface IRepositorioQuestao : IRepositorioBase<Questao>
    {
        void Inserir(Questao questao, List<Alternativa> alternativasAdicionadas);

        void Editar(int id, Questao questao, List<Alternativa> alternativas);

        void CarregarAlternativas(Questao questao);
    }
}
