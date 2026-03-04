using ApiEscola.Entidades;
using ApiEscola.Interfaces.Repositorio;
using ApiEscola.Interfaces.Servicos;
using ApiEscola.Servicos.Genericos;

namespace ApiEscola.Servicos
{
    public class ServicoTurma : ServicoCrud<Turma>, IServicoTurma
    {
        public ServicoTurma(IRepositorio<Turma> repositorio) : base(repositorio)
        {
        }
    }
}
