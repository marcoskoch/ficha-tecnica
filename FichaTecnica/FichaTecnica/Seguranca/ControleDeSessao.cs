using FichaTecnica.Dominio;
using FichaTecnica.Repositorio.EF;
using FichaTecnica.Seguranca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FichaTecnica.Seguranca
{
    public class ControleDeSessao
    {
        private const string USUARIO_LOGADO = "USUARIO_LOGADO";

        public static UsuarioLogado UsuarioLogado
        {
            get
            {
                return HttpContext.Current.Session[USUARIO_LOGADO] as UsuarioLogado;
            }
        }

        public static void CriarSessaoDeUsuario(Usuario usuario)
        {
            FormsAuthentication.SetAuthCookie(usuario.Email, true);
            HttpContext.Current.Session[USUARIO_LOGADO] = new UsuarioLogado(usuario);
        }

        public static void Encerrar()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Abandon();
        }
    }
}