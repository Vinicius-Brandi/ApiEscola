using System.ComponentModel.DataAnnotations;

namespace ApiEscola.Entidades
{
    public class EntidadeBase
    {
        [Key]
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataExclui { get; set; }
    }
}
