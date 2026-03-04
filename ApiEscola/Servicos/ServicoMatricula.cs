using ApiEscola.Entidades;
using ApiEscola.Interfaces.Repositorio;
using ApiEscola.Interfaces.Servicos;
using ApiEscola.Servicos.Genericos;

namespace ApiEscola.Servicos
{
    public class ServicoMatricula : ServicoCrud<Matricula>, IServicoMatricula
    {
        private readonly IRepositorio<Turma> _repositorioTurma;
        private readonly IRepositorio<Aluno> _repositorioAluno;

        public ServicoMatricula(
            IRepositorio<Matricula> repositorio,
            IRepositorio<Turma> repositorioTurma,
            IRepositorio<Aluno> repositorioAluno) : base(repositorio)
        {
            _repositorioTurma = repositorioTurma;
            _repositorioAluno = repositorioAluno;
        }

        public override bool Valida(Matricula entidade)
        {
            Mensagens.Clear();

            var turma = _repositorioTurma.Retorna(entidade.IdTurma);
            if (turma == null)
                Mensagens.Add(ServicoMensagem.Erro("Turma não encontrada"));

            var aluno = _repositorioAluno.Retorna(entidade.IdAluno);
            if (aluno == null)
                Mensagens.Add(ServicoMensagem.Erro("Aluno não encontrado"));

            var jaMatriculado = _repositorio.RetornaTodos().Any(m => m.IdAluno == entidade.IdAluno && m.IdTurma == entidade.IdTurma);

            if (jaMatriculado)
            {
                Mensagens.Add(ServicoMensagem.Erro("Aluno já matriculado nessa turma"));
            }

            if (Mensagens.Count > 0)
                return false;

            return true;
        }

        public bool CancelarMatricula(long idAluno, long idTurma)
        {
            Mensagens.Clear();
            var matricula = _repositorio.RetornaTodos()
                .FirstOrDefault(m => m.IdAluno == idAluno && m.IdTurma == idTurma);

            if (matricula == null)
            {
                Mensagens.Add(ServicoMensagem.Erro("Matrícula não encontrada"));
                return false;
            }

            Excluir(matricula);
            return true;
        }

        public List<Aluno> RetornaAlunosDaTurma(long idTurma)
        {
            var idsAlunos = _repositorio.RetornaTodos().Where(m => m.IdTurma == idTurma)
                .Select(m => m.IdAluno).ToHashSet();

            return _repositorioAluno.RetornaTodos().Where(a => idsAlunos.Contains(a.Id))
                .ToList();
        }

        public List<Turma> RetornaTurmasDoAluno(long idAluno)
        {
            var idsTurmas = _repositorio.RetornaTodos().Where(m => m.IdAluno == idAluno)
                .Select(m => m.IdTurma).ToHashSet();

            return _repositorioTurma.RetornaTodos()
                .Where(t => idsTurmas.Contains(t.Id)).ToList();
        }

        public void ExcluirMatriculasDoAluno(long idAluno)
        {
            var matriculas = _repositorio.RetornaTodos().Where(m => m.IdAluno == idAluno).ToList();

            foreach (var matricula in matriculas)
                Excluir(matricula);
        }

        public void ExcluirMatriculasDaTurma(long idTurma)
        {
            var matriculas = _repositorio.RetornaTodos().Where(m => m.IdTurma == idTurma)
                .ToList();

            foreach (var matricula in matriculas)
                Excluir(matricula);
        }
    }
}
