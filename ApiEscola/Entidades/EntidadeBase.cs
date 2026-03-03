namespace ApiEscola.Entidades
{
    public class EntidadeBase
    {
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataExclui { get; set; }
    }
}
