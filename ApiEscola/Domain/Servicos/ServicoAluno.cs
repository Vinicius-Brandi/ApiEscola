using ApiEscola.Domain.Entidades;
using ApiEscola.Domain.Interfaces.Repositorio;
using ApiEscola.Domain.Interfaces.Servicos;
using ApiEscola.Domain.Servicos.Genericos;

namespace ApiEscola.Domain.Servicos
{
    public class ServicoAluno : ServicoCrud<Aluno>, IServicoAluno
    {
        private readonly IServicoMatricula _servicoMatricula;

        public ServicoAluno(IRepositorio<Aluno> repositorio, IServicoMatricula servicoMatricula) : base(repositorio)
        {
            _servicoMatricula = servicoMatricula;
        }

        public override bool Valida(Aluno aluno)
        {
            var alunos = _repositorio.RetornaTodos().ToList();
            if (alunos.Any(a => a.Email != null && a.Email.Equals(aluno.Email, StringComparison.OrdinalIgnoreCase) && a.Id != aluno.Id))
            {
                Mensagens.Add(ServicoMensagem.Erro("Já existe um aluno cadastrado com este e-mail."));
                return false;
            }
            return true;
        }

        public override Aluno Excluir(Aluno entidade)
        {
            _servicoMatricula.ExcluirMatriculasDoAluno(entidade.Id);
            return base.Excluir(entidade);
        }

        public Matricula Matricular(Matricula matricula)
        {
            Mensagens.Clear();
            var retorno = _servicoMatricula.Incluir(matricula);
            if (retorno == null)
            {
                foreach (var mensagem in _servicoMatricula.Mensagens)
                    Mensagens.Add(mensagem);
            }
            return retorno;
        }

        public bool CancelarMatricula(long idAluno, long idTurma)
        {
            Mensagens.Clear();
            var retorno = _servicoMatricula.CancelarMatricula(idAluno, idTurma);
            if (!retorno)
            {
                foreach (var mensagem in _servicoMatricula.Mensagens)
                    Mensagens.Add(mensagem);
            }
            return retorno;
        }

        public List<Turma> RetornaTurmasDoAluno(long idAluno)
        {
            return _servicoMatricula.RetornaTurmasDoAluno(idAluno);
        }
    }
}
