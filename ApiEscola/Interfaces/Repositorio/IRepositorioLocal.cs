using ApiEscola.Entidades;

namespace ApiEscola.Interfaces.Repositorio
{
    public interface IRepositorioLocal<T>
        where T : EntidadeBase
    {
        T Retorna(long id);
        List<T> RetornaTodos();

        T Incluir(T entidade);
        T Excluir(T entidade);
        T Editar(T entidade);
    }
}
