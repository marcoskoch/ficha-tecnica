using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnica.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FichaTecnica.Dominio;

namespace FichaTecnica.Tests
{
    [TestClass]
    public class MembroRepositorioTest
    {
        [TestMethod]
        public void totalDeMembrosNoBancoIgualA2()
        {
            MembroRepositorioMock mock = new MembroRepositorioMock();
            IList<Membro> membros = mock.BuscarTodosMembros();

            int totalDeMembrosEsperado = 2;

            Assert.AreEqual(totalDeMembrosEsperado, membros.Count);
        }

        [TestMethod]
        public void buscarMembroComNomeRyu()
        {
            MembroRepositorioMock mock = new MembroRepositorioMock();
            IList<Membro> membros = mock.BuscarPorNome("Ryu");
            Membro membro = membros[0];

            string nomeMembroEsperado = "Ryu";

            Assert.AreEqual(nomeMembroEsperado, membro.Nome);
        }

        [TestMethod]
        public void buscarMembroComNomeKen()
        {
            MembroRepositorioMock mock = new MembroRepositorioMock();
            IList<Membro> membros = mock.BuscarPorNome("Ken");
            Membro membro = membros[0];

            string nomeMembroEsperado = "Ken";

            Assert.AreEqual(nomeMembroEsperado, membro.Nome);
        }

        [TestMethod]
        public void buscaMembrosDoProjetoComId1()
        {
            MembroRepositorioMock mock = new MembroRepositorioMock();
            Projeto projeto1 = new Projeto()
            {
                Id = 1
            };

            IList<Membro> membros = mock.BuscarMembroPorProjeto(projeto1);

            int totalDeMembrosEsperado = 2;

            Assert.AreEqual(totalDeMembrosEsperado, membros.Count);
        }

        [TestMethod]
        public void buscaMembrosDoProjetoComId2()
        {
            MembroRepositorioMock mock = new MembroRepositorioMock();
            Projeto projeto1 = new Projeto()
            {
                Id = 2
            };

            IList<Membro> membros = mock.BuscarMembroPorProjeto(projeto1);

            int totalDeMembrosEsperado = 2;

            Assert.AreEqual(totalDeMembrosEsperado, membros.Count);
        }

        [TestMethod]
        public void buscaMembroComIdIgualA1()
        {
            MembroRepositorioMock mock = new MembroRepositorioMock();
            Membro membro = mock.BuscarPorId(1);

            string nomeDoMembroEsperado = "Ryu";
            string emailDoMembroEsperado = "Ryu@cwi.com.br";

            Assert.AreEqual(nomeDoMembroEsperado, membro.Nome);
            Assert.AreEqual(emailDoMembroEsperado, membro.Email);
        }

        [TestMethod]
        public void buscaMembroComIdIgualA2()
        {
            MembroRepositorioMock mock = new MembroRepositorioMock();
            Membro membro = mock.BuscarPorId(2);

            string nomeDoMembroEsperado = "Ken";
            string emailDoMembroEsperado = "Ken@cwi.com.br";

            Assert.AreEqual(nomeDoMembroEsperado, membro.Nome);
            Assert.AreEqual(emailDoMembroEsperado, membro.Email);
        }

        [TestMethod]
        public void buscaLiderTecnicoDoProjetoNaoHaLiderTecnico()
        {
            MembroRepositorioMock mock = new MembroRepositorioMock();
            var membros = new List<Membro>();

            var Cargo1 = new Cargo()
            {
                Id = 1,
                Descricao = "Desenvolvedor"
            };

            var membro1 = new Membro()
            {
                Id = 1,
                Nome = "Ryu",
                Email = "Ryu@cwi.com.br",
                DataDeNascimento = new DateTime(12 / 12 / 2015),
                Telefone = "0102030405",
                Cargo = Cargo1,
                IdCargo = 1
            };

            membros.Add(membro1);

            Membro liderTecnico = mock.BuscarLiderTecnicoDoProjeto(membros);

            string nomeLiderTecnicoEsperado = "Não há líder técnico no projeto";
            string EmailLiderTecnicoEsperado = "Não há líder técnico no projeto";

            Assert.AreEqual(nomeLiderTecnicoEsperado, liderTecnico.Nome);
            Assert.AreEqual(EmailLiderTecnicoEsperado, liderTecnico.Email);
        }

        [TestMethod]
        public void buscaLiderTecnicoDoProjeto()
        {
            MembroRepositorioMock mock = new MembroRepositorioMock();
            var membros = new List<Membro>();

            var Cargo1 = new Cargo()
            {
                Id = 3,
                Descricao = "Líder Técnico"
            };

            var membro1 = new Membro()
            {
                Id = 1,
                Nome = "Ryu",
                Email = "Ryu@cwi.com.br",
                DataDeNascimento = new DateTime(12 / 12 / 2015),
                Telefone = "0102030405",
                Cargo = Cargo1,
                IdCargo = 3
            };

            membros.Add(membro1);

            Membro liderTecnico = mock.BuscarLiderTecnicoDoProjeto(membros);

            string nomeLiderTecnicoEsperado = "Ryu";
            string EmailLiderTecnicoEsperado = "Ryu@cwi.com.br";

            Assert.AreEqual(nomeLiderTecnicoEsperado, liderTecnico.Nome);
            Assert.AreEqual(EmailLiderTecnicoEsperado, liderTecnico.Email);
        }
    }
}
