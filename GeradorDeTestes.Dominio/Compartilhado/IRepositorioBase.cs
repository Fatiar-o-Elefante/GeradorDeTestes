namespace GeradorDeTestes.Dominio.Compartilhado
{
    public interface IRepositorioBase<TEntidade> where TEntidade : EntidadeBase<TEntidade>
    {
        void Inserir(TEntidade novoRegistro);
        void Editar(int id, TEntidade registro);
        void Excluir(TEntidade registroSelecionado);
        TEntidade SelecionarPorId(int id);
        List<TEntidade> SelecionarTodos();
    }
}
