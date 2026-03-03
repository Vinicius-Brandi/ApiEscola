using ApiEscola.Entidades;
using ApiEscola.Interfaces.Repositorio;
using ApiEscola.Interfaces.Servicos;
using ApiEscola.Servicos.Genericos;

namespace ApiEscola.Servicos
{
    public class ServicoAluno : ServicoCrud<Aluno>, IServicoAluno
    {
        public ServicoAluno(IRepositorioLocal<Aluno> repositorio) : base(repositorio)
        {
        }
        public override bool Valida(Aluno entidade)
        {
            var alunos = _repositorio.RetornaTodos().ToList();
            if (alunos.Any(a => a.Email != null && a.Email.Equals(entidade.Email, StringComparison.OrdinalIgnoreCase) && a.Id != entidade.Id))
            {
                Mensagens.Add(ServicoMensagem.Erro("Já existe um aluno cadastrado com este e-mail."));
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
