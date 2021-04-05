using NUnit.Framework;
using RNCadastro;
using System.Collections.Generic;
using TOCadastro;

namespace RNCadastroTest
{

    public class RNPessoas_Incluir
    {

        [Test]
        public void IncluirComSucesso()
        {
            RNPessoas sut = new();
            ToPessoas to = new() { Nome = "Matheus", Endereco = "Rua 10", Telefone = "190" };
            Retorno<int> retIncluir = new();

            retIncluir = sut.Incluir(to);

            Assert.That(retIncluir.Ok);

        }

        [Test]
        public void IncluirComSucesso_ComIdIgnorado()
        {
            RNPessoas sut = new();
            ToPessoas to = new() { Id = 12321, Nome = "Matheus", Endereco = "Rua 10", Telefone = "190" };
            Retorno<int> retIncluir = new();

            retIncluir = sut.Incluir(to);

            Assert.That(retIncluir.Ok);

        }

        [Test]
        public void IncluirComFalha_CampoObrigatório_Nome()
        {
            RNPessoas sut = new();
            ToPessoas to = new() { Endereco = "Rua 10", Telefone = "190" };
            Retorno<int> retIncluir = new();

            retIncluir = sut.Incluir(to);

            Assert.That(!retIncluir.Ok);
            Assert.That(retIncluir.Mensagem, Is.EqualTo("Campo obrigatório NOME não informado."));

        }

        [Test]
        public void IncluirComFalha_CampoObrigatório_Endereco()
        {
            RNPessoas sut = new();
            ToPessoas to = new() { Nome = "João", Telefone = "190" };
            Retorno<int> retIncluir = new();

            retIncluir = sut.Incluir(to);

            Assert.That(!retIncluir.Ok);
            Assert.That(retIncluir.Mensagem, Is.EqualTo("Campo obrigatório ENDERECO não informado."));

        }

        [Test]
        public void IncluirComFalha_CampoObrigatório_Telefone()
        {
            RNPessoas sut = new();
            ToPessoas to = new() { Nome = "João", Endereco = "Avenida Oscar Filho" };
            Retorno<int> retIncluir = new();

            retIncluir = sut.Incluir(to);

            Assert.That(!retIncluir.Ok);
            Assert.That(retIncluir.Mensagem, Is.EqualTo("Campo obrigatório TELEFONE não informado."));
        }


    }

    public class RNPessoas_Listar
    {
        [Test]
        public void ListarComSucesso()
        {
            RNPessoas sut = new();
            ToPessoas to = new();
            Retorno<List<ToPessoas>> retListar = new();

            retListar = sut.Listar(to);

            Assert.That(retListar.Ok);
            Assert.That(retListar.Dados.Count, Is.GreaterThan(0));

            to = new() { Endereco = retListar.Dados[0].Endereco, Id = retListar.Dados[0].Id, Nome = retListar.Dados[0].Nome, Telefone = retListar.Dados[0].Telefone };

            Assert.That(to.Id != null);
            Assert.That(to.Nome != null);
            Assert.That(to.Endereco != null);
            Assert.That(to.Telefone != null);

        }

        [Test]
        public void ListarComSucesso_TodosCampos()
        {
            RNPessoas sut = new();
            ToPessoas to = new() { Nome = "Matheus", Endereco = "Rua 10", Telefone = "190" };
            Retorno<List<ToPessoas>> retListar = new();

            retListar = sut.Listar(to);

            Assert.That(retListar.Ok);
            Assert.That(retListar.Dados.Count, Is.GreaterThan(0));

            to = new() { Endereco = retListar.Dados[0].Endereco, Id = retListar.Dados[0].Id, Nome = retListar.Dados[0].Nome, Telefone = retListar.Dados[0].Telefone };

            Assert.That(to.Id != null);
            Assert.That(to.Nome != null);
            Assert.That(to.Endereco != null);
            Assert.That(to.Telefone != null);

        }

        [Test]
        public void ListarComSucesso_CampoID()
        {
            RNPessoas sut = new();
            ToPessoas to = new() { Id = 1 };
            Retorno<List<ToPessoas>> retListar = new();

            retListar = sut.Listar(to);

            Assert.That(retListar.Ok);
            Assert.That(retListar.Dados.Count, Is.EqualTo(1));

            to = new() { Endereco = retListar.Dados[0].Endereco, Id = retListar.Dados[0].Id, Nome = retListar.Dados[0].Nome, Telefone = retListar.Dados[0].Telefone };

            Assert.That(to.Id != null);
            Assert.That(to.Nome != null);
            Assert.That(to.Endereco != null);
            Assert.That(to.Telefone != null);

        }
    }

    public class RNPessoas_Alterar
    {
        [Test]
        public void AlterarComSucesso()
        {
            RNPessoas sut = new();
            ToPessoas to = new() { Nome = "Nome a ser Alterado", Endereco = "Rua da Alteração", Telefone = "5551982843950" };
            ToPessoas toAlterado = new() { Nome = "Nome JÁ Alterado" };

            Retorno<int> retIncluir = sut.Incluir(to);
            Assert.That(retIncluir.Ok);

            Retorno<List<ToPessoas>> retListar = sut.Listar(to);

            Assert.That(retListar.Ok);
            Assert.That(retListar.Dados.Count, Is.GreaterThan(0));

            to = new() { Endereco = retListar.Dados[0].Endereco, Id = retListar.Dados[0].Id, Nome = retListar.Dados[0].Nome, Telefone = retListar.Dados[0].Telefone };

            Assert.That(to.Id != null);
            Assert.That(to.Nome != null);
            Assert.That(to.Endereco != null);
            Assert.That(to.Telefone != null);

            toAlterado.Id = to.Id;

            Retorno<int> retAlterar = sut.Alterar(toAlterado);
            Assert.That(retAlterar.Ok);

            ToPessoas toComId = new() { Id = toAlterado.Id };

            retListar = sut.Listar(toComId);
            Assert.That(retListar.Ok);

            Assert.That(retListar.Dados.Count, Is.EqualTo(1));

            Assert.That(retListar.Dados[0].Id == toComId.Id);
            Assert.That(retListar.Dados[0].Nome == "Nome JÁ Alterado");
            Assert.That(retListar.Dados[0].Endereco == "Rua da Alteração");
            Assert.That(retListar.Dados[0].Telefone == "5551982843950");

            Retorno<int> retExcluir = sut.Excluir(toComId);
            Assert.That(retExcluir.Ok);

            retListar = sut.Listar(toComId);
            Assert.That(retListar.Ok);

            Assert.That(retListar.Dados.Count, Is.EqualTo(0));

        }
    }
    public class RNPessoas_Excluir
    {
        [Test]
        public void AlterarComSucesso()
        {
            RNPessoas sut = new();
            ToPessoas to = new() { Nome = "Nome a ser Excluido", Endereco = "Rua da Exclusão", Telefone = "5551982843950" };

            Retorno<int> retIncluir = sut.Incluir(to);
            Assert.That(retIncluir.Ok);

            Retorno<List<ToPessoas>> retListar = sut.Listar(to);

            Assert.That(retListar.Ok);
            Assert.That(retListar.Dados.Count, Is.GreaterThan(0));

            to = new() { Endereco = retListar.Dados[0].Endereco, Id = retListar.Dados[0].Id, Nome = retListar.Dados[0].Nome, Telefone = retListar.Dados[0].Telefone };

            Assert.That(to.Id != null);
            Assert.That(to.Nome != null);
            Assert.That(to.Endereco != null);
            Assert.That(to.Telefone != null);


            Retorno<int> retExcluir = sut.Excluir(to);
            Assert.That(retExcluir.Ok);

        }
    }
}



