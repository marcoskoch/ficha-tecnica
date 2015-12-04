using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FichaTecnica.Tests.Mocks;
using FichaTecnica.Dominio;

namespace FichaTecnica.Tests
{
    [TestClass]
    public class TelaInicialTeste
    {
        [TestMethod]
        public void NomeProjetoUsuarioIgualAProjetoDeMock()
        {
            TelaInicialMock mocks = new TelaInicialMock();
            IList<Projeto> projetos = mocks.BuscarProjetosDoUsuario(1);

            string NomeProjetoEsperado = "Projeto de Mock";
            string NomeEncontrado = projetos[0].Nome;

            Assert.AreEqual(NomeProjetoEsperado, NomeEncontrado);
        }

        [TestMethod]
        public void DescricaoProjetoUSuarioIgualAProjetoDeMockParaTeste()
        {
            TelaInicialMock mocks = new TelaInicialMock();
            IList<Projeto> projetos = mocks.BuscarProjetosDoUsuario(1);

            string DescricaoProjetoEsperado = "Projeto De Mock Para Teste";
            string DescricaoEncontrada = projetos[0].Descricao;

            Assert.AreEqual(DescricaoProjetoEsperado, DescricaoEncontrada);
        }
    }
}
