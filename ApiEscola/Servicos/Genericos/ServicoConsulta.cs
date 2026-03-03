using ApiEscola.Entidades;
using ApiEscola.Interfaces.Repositorio;
using ApiEscola.Interfaces.Servicos.Genericos;
using ApiEscola.ObjetoValor;

namespace ApiEscola.Servicos.Genericos
{
    public class ServicoConsulta<T> : IServicoConsulta<T>
        where T : EntidadeBase
    {
        protected readonly IRepositorioLocal<T> _repositorio;
        public List<MensagemRetorno> Mensagens { get; protected set; }

        public ServicoConsulta(IRepositorioLocal<T> repositorio)
        {
            _repositorio = repositorio;
            Mensagens = new List<MensagemRetorno>();
        }

        public T Retorna(long id)
        {
            return _repositorio.Retorna(id);
        }

        public List<T> RetornaTodos()
        {
            return _repositorio.RetornaTodos();
        }
    }
}
