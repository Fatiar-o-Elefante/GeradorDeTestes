using GeradorDeTestes.Dominio.Compartilhado;

namespace GeradorDeTestes.Dominio.ModuloQuestoes
{
    public interface IRepositorioQuestoes : IRepositorioBase<Questao>
    {
        void Inserir(Questao questao, List<Alternativa> alternativasAdicionadas);

        void Editar(int id, Questao questao, List<Alternativa> alternativasMarcadas, List<Alternativa> alternativasDesmarcadas);
    }
}
