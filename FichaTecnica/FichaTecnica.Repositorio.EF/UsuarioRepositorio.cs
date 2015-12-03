using FichaTecnica.Dominio;
using FichaTecnica.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Repositorio.EF
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public Usuario BuscarPorEmail(string email)
        {
            //using (var db = new BancoDeDados())
            //{
            //    return db.Usuario.Include("Permissoes").FirstOrDefault(u => u.Email == email);
            //}

            Usuario usuario = new Usuario();
            usuario.Email = "gerente@cwi.com.br";
            usuario.Senha = "123";
            return usuario;
        }
    }
}
