using System;

namespace TOCadastro
{
    public struct Retorno<T>
    {
        public readonly T Dados;
        public readonly string Mensagem;
        public readonly bool Ok;

        private Retorno(T dados, string mensagem, bool ok)
        {
            Dados = dados;
            Mensagem = mensagem;
            Ok = ok;
        }

        public Retorno<T> RetornarFalha(string mensagem)
        {
            Retorno<T> retorno = new(default(T), mensagem, false);
            return retorno;
        }

        public Retorno<T> RetornarSucesso(T dados,string mensagem = "Operação Realizada Com Sucesso")
        {
            Retorno<T> retorno = new(dados, mensagem, true);
            return retorno;
        }
    }

    
}
