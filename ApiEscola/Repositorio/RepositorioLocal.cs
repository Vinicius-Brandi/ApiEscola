using ApiEscola.Entidades;
using ApiEscola.Interfaces.Repositorio;

namespace ApiEscola.Repositorio
{
    public class RepositorioLocal<T> : IRepositorio<T>
        where T : EntidadeBase
    {
        private readonly List<T> _dados;
        private long _idContador = 0;
        private readonly List<T> _lixo;

        public RepositorioLocal()
        {
            _dados = new List<T>();
            _lixo = new List<T>();
        }

        public virtual T Retorna(long id)
        {
            return _dados.FirstOrDefault(x => x.Id == id);
        }

        public virtual List<T> RetornaTodos()
        {
            return _dados;
        }

        public T Incluir(T entidade)
        {
            if (entidade.Id <= 0)
            {
                entidade.Id = Interlocked.Increment(ref _idContador);
            }
            else
            {
                var current = Interlocked.Read(ref _idContador);
                if (entidade.Id > current)
                {
                    Interlocked.Exchange(ref _idContador, entidade.Id);
                }
            }

            _dados.Add(entidade);
            return entidade;
        }

        public T Excluir(T entidade)
        {
            var existente = _dados.FirstOrDefault(x => x.Id == entidade.Id);
            if (existente != null)
            {
                _lixo.Add(existente);
                _dados.Remove(existente);
            }
            return existente;
        }

        public T Editar(T entidade)
        {
            var existente = _dados.FirstOrDefault(x => x.Id == entidade.Id);

            if (existente == null)
                return null;

            var index = _dados.IndexOf(existente);
            _dados[index] = entidade;

            return entidade;
        }
    }
}
