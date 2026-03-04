using System.ComponentModel.DataAnnotations;

namespace ApiEscola.Entidades
{
    public class Aluno : EntidadeBase
    {
        [Required(AllowEmptyStrings =false, ErrorMessage = "Primeiro Nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "Primeiro Nome deve ter no máximo 50 caracteres")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [RegularExpression(@"^[^@\s]+@faculdade\.edu$", ErrorMessage = "O e-mail deve terminar com @faculdade.edu.")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Aluno precisa ter uma turma")]
        public long TurmaId { get; set; }
    }
}
