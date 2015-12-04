using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FichaTecnica.Infraestrutura.Servicos.Test
{
    [TestClass]
    public class ServicoCriptografiaTeste
    {
        [TestMethod]
        public void CriptografaSenha()
        {
            var servicoCriptografia = new ServicoCriptografia();
            string senhaPadrao = "123";

            string senhaCriptografada = servicoCriptografia.CriptografarSenha(senhaPadrao);
            Assert.AreEqual("8502CD3ED213666DC2B730501A2A48B3", senhaCriptografada);
        }
    }
}
