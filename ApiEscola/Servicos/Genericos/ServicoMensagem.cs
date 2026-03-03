using ApiEscola.ObjetoValor;

namespace ApiEscola.Servicos.Genericos
{
    public static class ServicoMensagem
    {
        public static MensagemRetorno Erro(string mensagem) => new MensagemRetorno(TipoMensagem.Erro, mensagem);

        public static MensagemRetorno Sucesso(string mensagem) => new MensagemRetorno(TipoMensagem.Sucesso, mensagem);
    }
}
