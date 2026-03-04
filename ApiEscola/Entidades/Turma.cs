using System.Runtime.CompilerServices;

namespace ApiEscola.Entidades
{
    public class Turma : EntidadeBase
    {
        public int Ano {get; set;}
        public string Sala {get; set;}
        public List<Aluno> Alunos {get; set;}

    }
}
