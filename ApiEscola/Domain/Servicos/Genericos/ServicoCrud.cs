using ApiEscola.Domain.Entidades;
using ApiEscola.Domain.Interfaces.Repositorio;
using ApiEscola.Domain.Interfaces.Servicos.Genericos;

namespace ApiEscola.Domain.Servicos.Genericos
{
    public class ServicoCrud<T> : ServicoConsulta<T>, IServicoCrud<T>
        where T : EntidadeBase
    {
        public ServicoCrud(IRepositorio<T> repositorio) : base(repositorio)
        {
        }

        public virtual bool Valida(T entidade)
        {
            return true;
        }
        public virtual T Incluir(T entidade)
        {
            if(!Valida(entidade))
                return null;
            entidade.DataCriacao = DateTime.Now;
            entidade.DataExclui = null;
            return _repositorio.Incluir(entidade);
        }

        public virtual T Excluir(T entidade)
        {
            entidade.DataExclui = DateTime.Now;
            return _repositorio.Excluir(entidade);
        }

        public virtual T Editar(T entidade)
        {
            if(!Valida(entidade)) 
                return null;
            entidade.DataExclui = null;
            return _repositorio.Editar(entidade);
        }
    }
}
