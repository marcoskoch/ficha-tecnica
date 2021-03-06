﻿using FichaTecnica.Seguranca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FichaTecnica.Seguranca.Filters
{
    public class Autorizador : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            UsuarioLogado usuarioLogado = filterContext.HttpContext.Session["USUARIO_LOGADO"] as UsuarioLogado;

            if (usuarioLogado != null)
            {
                var identidade = new GenericIdentity(usuarioLogado.Email);
                List<string> roles = new List<string>();
                roles.Add(usuarioLogado.Perfil);

                var principal = new GenericPrincipal(identidade, roles.ToArray());

                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;

                base.OnAuthorization(filterContext);
            }
            else
            {
                filterContext.Controller.TempData.Add("MensagemErro", "Autentique-se primeiro");
                RedirecionarParaLogin(filterContext);
            }

        }

        private void RedirecionarParaLogin(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                        {"action", "Index" },
                        {"controller", "Login" }
                });
        }
    }
}