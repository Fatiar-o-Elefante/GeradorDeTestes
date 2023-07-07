using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloQuestoes;

namespace GeradorDeTestes.Dominio.ModuloTestes
{
    public interface IRepositorioTeste : IRepositorioBase<Teste>
    {
        void Inserir(Teste novoRegistro, List<Questao> questoesAdicionadas);
    }
}
