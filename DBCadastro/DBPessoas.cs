using System;
using System.Collections.Generic;
using TOCadastro;
using MySql.Data.MySqlClient;

namespace DBCadastro
{
    public class DBPessoas
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter dataAdapter;
        MySqlDataReader dataReader;
        string stringConnection = "Server = localhost; Database = Cadastros; Uid = root; Pwd = 12354";


        public Retorno<List<ToPessoas>> Listar(ToPessoas toPessoas)
        {
            string strCommand = "SELECT ID, NOME, ENDERECO, TELEFONE FROM CADASTROS.PESSOAS ";

            (bool where, string cmd) tID = (toPessoas.Id != null) ? (true, " @ID ,") : (false, "");
            (bool where, string cmd) tNome = (toPessoas.Nome != null) ? (true, " @NOME ,") : (false, "");
            (bool where, string cmd) tEndereco = (toPessoas.Endereco != null) ? (true, " @ENDERECO ,") : (false, "");
            (bool where, string cmd) tTelefone = (toPessoas.Telefone != null) ? (true, " @TELEFONE ,") : (false, "");

            strCommand += (tID.where || tNome.where || tEndereco.where || tTelefone.where) ? "WHERE " + tID.cmd + tNome.cmd + tEndereco.cmd + tTelefone.cmd : "";


            try
            {
                conexao = new(stringConnection);
                comando = new(strCommand, conexao);

                if (tID.where)
                {
                    comando.Parameters.AddWithValue("@ID", toPessoas.Id);
                }
                if (tNome.where)
                {
                    comando.Parameters.AddWithValue("@NOME", toPessoas.Nome);
                }
                if (tEndereco.where)
                {
                    comando.Parameters.AddWithValue("@ENDERECO", toPessoas.Endereco);
                }
                if (tTelefone.where)
                {
                    comando.Parameters.AddWithValue("@TELEFONE", toPessoas.Telefone);
                }

                conexao.Open();
                dataReader = comando.ExecuteReader();

                //dataReader em algo
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", dataReader.GetInt32(0),
                            dataReader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                dataReader.Close();

                //formar lista
                Retorno<List<ToPessoas>> ret = new();
                return ret.RetornarSucesso(new());

            }
            catch (Exception Ex)
            {
                Retorno<List<ToPessoas>> ret = new();
                return ret.RetornarFalha(Ex.Message);
            }
            finally
            {
                conexao.Close();
            }


        }

        public Retorno<Int32> Incluir(ToPessoas toPessoas)
        {
            string strCommand = "INSERT INTO CADASTROS.PESSOAS (ID, NOME, ENDERECO, TELEFONE) ";

            (bool where, string cmd) tID = (toPessoas.Id != null) ? (true, " @ID ,") : (false, "");
            (bool where, string cmd) tNome = (toPessoas.Nome != null) ? (true, " @NOME ,") : (false, "");
            (bool where, string cmd) tEndereco = (toPessoas.Endereco != null) ? (true, " @ENDERECO ,") : (false, "");
            (bool where, string cmd) tTelefone = (toPessoas.Telefone != null) ? (true, " @TELEFONE ,") : (false, "");

            strCommand += (tID.where || tNome.where || tEndereco.where || tTelefone.where) ? "VALUES ( " + tID.cmd + tNome.cmd + tEndereco.cmd + tTelefone.cmd : "";


            try
            {
                conexao = new(stringConnection);
                comando = new(strCommand, conexao);

                if (tID.where)
                {
                    comando.Parameters.AddWithValue("@ID", toPessoas.Id);
                }
                if (tNome.where)
                {
                    comando.Parameters.AddWithValue("@NOME", toPessoas.Nome);
                }
                if (tEndereco.where)
                {
                    comando.Parameters.AddWithValue("@ENDERECO", toPessoas.Endereco);
                }
                if (tTelefone.where)
                {
                    comando.Parameters.AddWithValue("@TELEFONE", toPessoas.Telefone);
                }

                conexao.Open();
                comando.ExecuteNonQuery();

                Retorno<int> ret = new();
                return ret.RetornarSucesso(1);

            }
            catch (Exception Ex)
            {
                Retorno<int> ret = new();
                return ret.RetornarFalha(Ex.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

        public Retorno<Int32> Alterar(ToPessoas toPessoas)
        {
            string strCommand = "UPDATE CADASTROS.PESSOAS SET ";

            (bool where, string cmd) tNome = (toPessoas.Nome != null) ? (true, " NOME = @NOME ,") : (false, "");
            (bool where, string cmd) tEndereco = (toPessoas.Endereco != null) ? (true, " ENDERECO = @ENDERECO ,") : (false, "");
            (bool where, string cmd) tTelefone = (toPessoas.Telefone != null) ? (true, " TELEFONE = @TELEFONE ,") : (false, "");
            (bool where, string cmd) tID = (toPessoas.Id != null) ? (true, "ID = @ID ") : (false, "");

            strCommand += (tID.where || tNome.where || tEndereco.where || tTelefone.where) ? tNome.cmd + tEndereco.cmd + tTelefone.cmd + " WHERE " + tID.cmd : "";


            try
            {
                conexao = new(stringConnection);
                comando = new(strCommand, conexao);

                if (tID.where)
                {
                    comando.Parameters.AddWithValue("@ID", toPessoas.Id);
                }
                if (tNome.where)
                {
                    comando.Parameters.AddWithValue("@NOME", toPessoas.Nome);
                }
                if (tEndereco.where)
                {
                    comando.Parameters.AddWithValue("@ENDERECO", toPessoas.Endereco);
                }
                if (tTelefone.where)
                {
                    comando.Parameters.AddWithValue("@TELEFONE", toPessoas.Telefone);
                }

                conexao.Open();
                comando.ExecuteNonQuery();

                Retorno<int> ret = new();
                return ret.RetornarSucesso(1);

            }
            catch (Exception Ex)
            {
                Retorno<int> ret = new();
                return ret.RetornarFalha(Ex.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

        public Retorno<Int32> Excluir(ToPessoas toPessoas)
        {
            string strCommand = "DELETE FROM CADASTROS.PESSOAS ";

            (bool where, string cmd) tID = (toPessoas.Id != null) ? (true, "ID = @ID ") : (false, "");

            strCommand += (tID.where) ? " WHERE " + tID.cmd : "";


            try
            {
                conexao = new(stringConnection);
                comando = new(strCommand, conexao);

                if (tID.where)
                {
                    comando.Parameters.AddWithValue("@ID", toPessoas.Id);
                }

                conexao.Open();
                comando.ExecuteNonQuery();

                Retorno<int> ret = new();
                return ret.RetornarSucesso(1);

            }
            catch (Exception Ex)
            {
                Retorno<int> ret = new();
                return ret.RetornarFalha(Ex.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

    }
}
