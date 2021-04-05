using System;
using System.Collections.Generic;
using TOCadastro;
using DBCadastro;

namespace RNCadastro
{
    public class RNPessoas
    {
        public Retorno<List<ToPessoas>> Listar(ToPessoas toPessoas)
        {
            try
            {
                //TODO: regras de negócio

                DBPessoas bdPessoas = new();
                Retorno<List<ToPessoas>> retListar = bdPessoas.Listar(toPessoas);
                if (!retListar.Ok)
                {
                    return retListar.RetornarFalha("Falha ao Listar : "+retListar.Mensagem);
                }
                return retListar.RetornarSucesso(retListar.Dados,retListar.Mensagem);
            }
            catch (Exception e)
            {
                Retorno<List<ToPessoas>> retListar = new();
                return retListar.RetornarFalha("Falha ao Listar : " + e.Message);
            }
        }

        public Retorno<Int32> Incluir(ToPessoas toPessoas)
        {
            try
            {
                Retorno<Int32> retIncluir = new();

                #region Validação de campos obrigatórios
                if (toPessoas.Endereco == null)
                {
                    return retIncluir.RetornarFalha("Campo obrigatório ENDERECO não informado.");
                }             
                if (toPessoas.Nome == null)
                {
                    return retIncluir.RetornarFalha("Campo obrigatório NOME não informado.");
                }
                if (toPessoas.Telefone == null)
                {
                    return retIncluir.RetornarFalha("Campo obrigatório TELEFONE não informado.");
                }
                #endregion

                toPessoas.Id = null;

                retIncluir = new();

                DBPessoas bdPessoas = new();
                retIncluir = bdPessoas.Incluir(toPessoas);
                if (!retIncluir.Ok)
                {
                    return retIncluir.RetornarFalha("Falha ao Listar : " + retIncluir.Mensagem);
                }
                return retIncluir.RetornarSucesso(retIncluir.Dados, retIncluir.Mensagem);
            }
            catch (Exception e)
            {
                Retorno<Int32> retIncluir = new();
                return retIncluir.RetornarFalha("Falha ao Incluir : " + e.Message);
            }
        }

        public Retorno<Int32> Alterar(ToPessoas toPessoas)
        {
            try
            {
                Retorno<Int32> retAlterar = new();

                #region Validação dos campos da chave primária
                if (toPessoas.Id == null)
                {
                    return retAlterar.RetornarFalha("Campo obrigatório ID não informado.");
                }
                #endregion
                //TODO: regras de negócio
                DBPessoas bdPessoas = new();
               
                    retAlterar = bdPessoas.Alterar(toPessoas);
                    if (!retAlterar.Ok)
                    {
                        return retAlterar.RetornarFalha(retAlterar.Mensagem);
                    }
              
                return retAlterar.RetornarSucesso(retAlterar.Dados,retAlterar.Mensagem);
            }
            catch (Exception e)
            {
                Retorno<Int32> retAlterar = new();
                return retAlterar.RetornarFalha("Falha ao Alterar : " + e.Message);
            }
        }

        public Retorno<Int32> Excluir(ToPessoas toPessoas)
        {
            try
            {
                Retorno<Int32> retExcluir = new();

                #region Validação dos campos da chave primária
                if (toPessoas.Id == null)
                {
                    return retExcluir.RetornarFalha("Campo obrigatório ID não informado.");
                }
                #endregion
                //TODO: regras de negócio
                DBPessoas bdPessoas = new();

                retExcluir = bdPessoas.Excluir(toPessoas);
                if (!retExcluir.Ok)
                {
                    return retExcluir.RetornarFalha(retExcluir.Mensagem);
                }

                return retExcluir.RetornarSucesso(retExcluir.Dados, retExcluir.Mensagem);
            }
            catch (Exception e)
            {
                Retorno<Int32> retAlterar = new();
                return retAlterar.RetornarFalha("Falha ao Excluir : " + e.Message);
            }
        }

    }
}
