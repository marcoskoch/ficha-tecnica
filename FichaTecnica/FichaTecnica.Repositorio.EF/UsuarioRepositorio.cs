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
            using (var db = new BaseDeDados())
            {
                return db.Usuario.Include("Permissao").FirstOrDefault(u => u.Email == email);
            }

        }
    }
}
