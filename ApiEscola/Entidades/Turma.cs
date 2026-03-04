using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ApiEscola.Entidades
{
    public class Turma : EntidadeBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ano da turma é obrigatorio")]
        public int Ano {get; set;}
        [Required(AllowEmptyStrings = false, ErrorMessage = "O nome do curso é obrigatório")]
        public string Curso {get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "O nome da turma é obrigatório")]
        public string Sala {get; set;}
    }
}
