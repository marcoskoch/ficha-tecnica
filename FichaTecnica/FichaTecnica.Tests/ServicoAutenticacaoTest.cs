using FichaTecnica.Dominio;
using FichaTecnica.Dominio.Servicos;
using FichaTecnica.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Tests
{
    [TestClass]
    public class ServicoAutenticacaoTest
    {
        [TestMethod]
        public void VerificaoSenhaUsuario()
        {
            ServicoAutenticacao servico = CriarServicoAutenticacao();
            Usuario user = servico.BuscarPorAutenticacao("gerente@cwi.com.br", "123");

            Assert.IsNotNull(user);
        }

        private ServicoAutenticacao CriarServicoAutenticacao()
        {
            return new ServicoAutenticacao(new UsuarioRepositorioMock(), new ServicoCriptografiaMock());
        }
    }

}
