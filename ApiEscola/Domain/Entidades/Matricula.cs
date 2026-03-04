using System.ComponentModel.DataAnnotations;

namespace ApiEscola.Domain.Entidades
{
    public class Matricula : EntidadeBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Id do aluno é obrigatorio")]
        public long IdAluno { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Id da Turma é obrigatorio")]
        public long IdTurma { get; set; }
    }
}
