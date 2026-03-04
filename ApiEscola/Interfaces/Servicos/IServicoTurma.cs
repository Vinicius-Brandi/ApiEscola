using ApiEscola.Entidades;
using ApiEscola.Interfaces.Servicos.Genericos;

namespace ApiEscola.Interfaces.Servicos
{
    public interface IServicoTurma : IServicoCrud<Turma>
    {
        List<Aluno> RetornaAlunosDaTurma(long idTurma);
    }
}
