using FichaTecnica.Dominio;
using FichaTecnica.Dominio.Repositorio;
using FichaTecnica.Models;
using FichaTecnica.Repositorio.EF;
using FichaTecnica.Seguranca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FichaTecnica.Controllers
{
    public class ProjetoController : Controller
    {
        private IProjetoRepositorio dataBase = new ProjetoRepositorio();

        // GET: Projeto
        public ActionResult CadastroProjeto()
        {
            UsuarioLogado usuario = (UsuarioLogado)Session["USUARIO_LOGADO"];
            ProjetoModel model = new ProjetoModel();

            model.IdUsuario = usuario.Id;

            return View(model);
        }

        public ActionResult Salvar(ProjetoModel model)
        {
            if (ModelState.IsValid)
            {
                Projeto projeto = new Projeto()
                {
                    Nome = model.Nome,
                    Descricao = model.Descricao,
                    DataInicio = DateTime.Now,
                    IdUsuario = model.IdUsuario
                };

                var id = dataBase.CadastrarNovoProjeto(projeto);

                return RedirectToAction("TelaInicial", "TelaInicial");

            }

            ModelState.AddModelError("INVALID_LOGIN", "Usuário ou senha inválidos.");
            return View("CadastroProjeto", model);
        }
    }
}