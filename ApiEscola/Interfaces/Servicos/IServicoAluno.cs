using ApiEscola.Entidades;
using ApiEscola.Interfaces.Servicos.Genericos;

namespace ApiEscola.Interfaces.Servicos
{
    public interface IServicoAluno : IServicoCrud<Aluno>
    {
        public Aluno Matricular(Aluno aluno);
    }
}
