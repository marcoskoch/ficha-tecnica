using FichaTecnica.Dominio;
using FichaTecnica.Dominio.Repositorio;
using FichaTecnica.Models;
using FichaTecnica.Seguranca.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FichaTecnica.Controllers
{
    public class TelaInicialController : Controller
    {
        private IProjetoRepositorio dataBase = new FichaTecnica.Repositorio.EF.ProjetoRepositorio();

        [Autorizador]
        public ActionResult TelaInicial(/*int idUsuario*/)
        {
            int IDUsuario = 1;
            List<Projeto> projetos = dataBase.BuscarProjetosDoUsuario(IDUsuario);

            TelaInicialModel model = new TelaInicialModel();
            model.projetos = new List<Projeto>();
            model.projetos = projetos;

            return View(model);
        }

        public ActionResult ProjetoDetalhe(int idProjeto)
        {
            return null;
        }
    }
}