using ApiEscola.Domain.Entidades;
using ApiEscola.Domain.Interfaces.Servicos.Genericos;

namespace ApiEscola.Domain.Interfaces.Servicos
{
    public interface IServicoMatricula : IServicoCrud<Matricula>
    {
        bool CancelarMatricula(long idAluno, long idTurma);
        List<Aluno> RetornaAlunosDaTurma(long idTurma);
        List<Turma> RetornaTurmasDoAluno(long idAluno);
        void ExcluirMatriculasDoAluno(long idAluno);
        void ExcluirMatriculasDaTurma(long idTurma);
    }
}
