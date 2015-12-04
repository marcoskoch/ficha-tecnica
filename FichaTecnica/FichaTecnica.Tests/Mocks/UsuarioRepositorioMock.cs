using FichaTecnica.Dominio;
using FichaTecnica.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Tests.Mocks
{
    public class UsuarioRepositorioMock : IUsuarioRepositorio
    {
        public Usuario BuscarPorEmail(string email)
        {
            return Db().FirstOrDefault(u => u.Email.Equals(email));
        }

        private IList<Usuario> Db()
        {
            var usuarios = new List<Usuario>();

            var usuario1 = new Usuario()
            {
                Email = "gerente@cwi.com.br",
                Senha = "senhacriptografada"
            };

            usuarios.Add(usuario1);
            return usuarios;
        }

        public Usuario BuscarPorId(int Id)
        {
            return null;
        }
    }
}
