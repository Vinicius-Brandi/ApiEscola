using ApiEscola.Entidades;
using ApiEscola.Interfaces.Repositorio;
using ApiEscola.Interfaces.Servicos;
using ApiEscola.Servicos.Genericos;

namespace ApiEscola.Servicos
{
    public class ServicoAluno : ServicoCrud<Aluno>, IServicoAluno
    {
        private readonly ServicoTurma _servicoTurma;
        public ServicoAluno(IRepositorio<Aluno> repositorio) : base(repositorio)
        {
        }
        public override bool Valida(Aluno aluno)
        {
            var alunos = _repositorio.RetornaTodos().ToList();
            if (alunos.Any(a => a.Email != null && a.Email.Equals(aluno.Email, StringComparison.OrdinalIgnoreCase) && a.Id != aluno.Id))
            {
                Mensagens.Add(ServicoMensagem.Erro("Já existe um aluno cadastrado com este e-mail."));
                return false;
            }
            try
            {
                Turma turma = _servicoTurma.Retorna(aluno.TurmaId);
            }
            catch
            {
                Mensagens.Add(ServicoMensagem.Erro("Turma não existe"));
                return false;
            }
            return true;
        }
        public Aluno Matricular(Aluno aluno)
        {
            Mensagens.Clear();

            var criado = Incluir(aluno);
            if(criado != null) 
                Mensagens.Add(ServicoMensagem.Sucesso("Aluno matriculado com sucesso."));

            return criado;
        }
    }
}
