using FichaTecnica.Dominio;
using FichaTecnica.Dominio.Repositorio;
using FichaTecnica.Dominio.Servicos;
using FichaTecnica.Helpers;
using FichaTecnica.Models;
using FichaTecnica.Repositorio.EF;
using FichaTecnica.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FichaTecnica.Controllers
{
    public class LoginController : Controller
    {
        private IUsuarioRepositorio dataBase = new UsuarioRepositorio();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sair()
        {
            ControleDeSessao.Encerrar();

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                ServicoAutenticacao servicoAutenticacao = FabricaDeModulos.CriarServicoAutenticacao();

               Usuario usuarioAutenticado = servicoAutenticacao.BuscarPorAutenticacao(loginModel.Email, loginModel.Senha);

                if (usuarioAutenticado != null)
                {
                    ControleDeSessao.CriarSessaoDeUsuario(usuarioAutenticado);
                    return RedirectToAction("Index", "TelaInicial");
                }
            }

            ModelState.AddModelError("INVALID_LOGIN", "Usuário ou senha inválidos.");
            return View("Index", loginModel);
        }
    }
}