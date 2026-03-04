using ApiEscola.Domain.Entidades;

namespace ApiEscola.Domain.Interfaces.Servicos.Genericos
{
    public interface IServicoCrud<T> : IServicoConsulta<T> where T : EntidadeBase
    {
        public T Incluir(T entidade);
        public T Excluir(T entidade);
        public T Editar(T entidade);
    }
}
