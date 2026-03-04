using ApiEscola.Domain.Entidades;
using ApiEscola.Domain.Interfaces.Servicos.Genericos;

namespace ApiEscola.Domain.Interfaces.Servicos
{
    public interface IServicoTurma : IServicoCrud<Turma>
    {
        List<Aluno> RetornaAlunosDaTurma(long idTurma);
    }
}
