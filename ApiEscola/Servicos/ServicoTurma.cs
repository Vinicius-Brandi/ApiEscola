using ApiEscola.Entidades;
using ApiEscola.Interfaces.Repositorio;
using ApiEscola.Interfaces.Servicos;
using ApiEscola.Servicos.Genericos;

namespace ApiEscola.Servicos
{
    public class ServicoTurma : ServicoCrud<Turma>, IServicoTurma
    {
        public ServicoTurma(IRepositorioTurma repositorio) : base(repositorio)
        {
        }
    }
}
