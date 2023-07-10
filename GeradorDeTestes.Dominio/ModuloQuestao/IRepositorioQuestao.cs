using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloTestes;

namespace GeradorDeTestes.Dominio.ModuloQuestoes
{
    public interface IRepositorioQuestao : IRepositorioBase<Questao>
    {
        void Inserir(Questao questao, List<Alternativa> alternativasAdicionadas);

        void Editar(int id, Questao questao, List<Alternativa> alternativas);

        public void Excluir(Questao questao, List<Teste> testes);

        void CarregarAlternativas(Questao questao);
    }
}
