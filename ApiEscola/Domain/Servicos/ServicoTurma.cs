using ApiEscola.Domain.Entidades;
using ApiEscola.Domain.Interfaces.Repositorio;
using ApiEscola.Domain.Interfaces.Servicos;
using ApiEscola.Domain.Servicos.Genericos;

namespace ApiEscola.Domain.Servicos
{
    public class ServicoTurma : ServicoCrud<Turma>, IServicoTurma
    {
        private readonly IServicoMatricula _servicoMatricula;

        public ServicoTurma(IRepositorio<Turma> repositorio, IServicoMatricula servicoMatricula) : base(repositorio)
        {
            _servicoMatricula = servicoMatricula;
        }

        public override Turma Excluir(Turma entidade)
        {
            _servicoMatricula.ExcluirMatriculasDaTurma(entidade.Id);
            return base.Excluir(entidade);
        }

        public List<Aluno> RetornaAlunosDaTurma(long idTurma)
        {
            return _servicoMatricula.RetornaAlunosDaTurma(idTurma);
        }
    }
}
