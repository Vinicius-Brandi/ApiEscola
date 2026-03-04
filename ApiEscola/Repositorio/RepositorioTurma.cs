using ApiEscola.Data.Context;
using ApiEscola.Entidades;
using ApiEscola.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace ApiEscola.Repositorio
{
    public class RepositorioTurmaBanco : RepositorioBanco<Turma>, IRepositorioTurma
    {
        public RepositorioTurmaBanco(EscolaContext context) : base(context)
        {
        }
        public override Turma Retorna(long id)
        {
            return _dbSet
                .Include(t => t.Alunos)
                .FirstOrDefault(t => t.Id == id);
        }

        public override List<Turma> RetornaTodos()
        {
            return _dbSet.Include(t => t.Alunos)
                .ToList();
        }
    }

    namespace ApiEscola.Repositorio
    {
        public class RepositorioTurmaLocal : RepositorioLocal<Turma>, IRepositorioTurma
        {
            private readonly IRepositorio<Aluno> _repositorioAlunos;

            public RepositorioTurmaLocal(IRepositorio<Aluno> repositorioAlunos)
            {
                _repositorioAlunos = repositorioAlunos;
            }

            public override Turma Retorna(long id)
            {
                var turma = base.Retorna(id);
                if (turma != null)
                {
                    turma.Alunos = _repositorioAlunos.RetornaTodos()
                        .Where(a => a.TurmaId == turma.Id)
                        .ToList();
                }

                return turma;
            }

            public override List<Turma> RetornaTodos()
            {
                var turmas = base.RetornaTodos();
                var todosAlunos = _repositorioAlunos.RetornaTodos();

                foreach (var turma in turmas)
                {
                    turma.Alunos = todosAlunos
                        .Where(a => a.TurmaId == turma.Id)
                        .ToList();
                }

                return turmas;
            }
        }
    }
}
