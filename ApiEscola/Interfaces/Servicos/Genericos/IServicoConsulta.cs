using ApiEscola.Entidades;
using ApiEscola.ObjetoValor;

namespace ApiEscola.Interfaces.Servicos.Genericos
{
    public interface IServicoConsulta<T> where T : EntidadeBase
    {
        public T Retorna(long id);
        public List<T> RetornaTodos();
        public List<MensagemRetorno> Mensagens { get; }
    }
}
