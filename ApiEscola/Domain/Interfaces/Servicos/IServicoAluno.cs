using ApiEscola.Domain.Entidades;
using ApiEscola.Domain.Interfaces.Servicos.Genericos;

namespace ApiEscola.Domain.Interfaces.Servicos
{
    public interface IServicoAluno : IServicoCrud<Aluno>
    {
        Matricula Matricular(Matricula matricula);
        bool CancelarMatricula(long idAluno, long idTurma);
        List<Turma> RetornaTurmasDoAluno(long idAluno);
    }
}
