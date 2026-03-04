namespace ApiEscola.Domain.ObjetoValor
{
    public class MensagemRetorno
    {
        public TipoMensagem Tipo { get; set; }
        public string Mensagem { get; set; }
        public MensagemRetorno(TipoMensagem tipo, string mensagem)
        {
            Tipo = tipo;
            Mensagem = mensagem;
        }
    }
}
