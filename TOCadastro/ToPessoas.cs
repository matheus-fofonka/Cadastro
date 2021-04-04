using System;

namespace TOCadastro
{
    public class ToPessoas
    {
        #region Campos da Tabela
        private int? id;
        private string? nome;
        private string? endereco;
        private string? telefone;
        #endregion

        #region Propriedades
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        #endregion

        #region Metodos
        public void PopularRetorno(string linha)
        {
            //TODO
        }
        #endregion
    }
}
