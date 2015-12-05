using FichaTecnica.Dominio;
using FichaTecnica.Dominio.Repositorio;
using FichaTecnica.Models;
using FichaTecnica.Repositorio.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FichaTecnica.Controllers
{
    public class MembroController : Controller
    {

        private IMembroRepositorio dataBase = new MembroRepositorio();

        public ActionResult FichaMembro(int id)
        {
            var membroModel = new DetalheMembroModel(dataBase.BuscarPorId(id));
            List<LinkFork> links = dataBase.BuscarLinkPorIdMembro(id);

            DateTime zeroTime = new DateTime(1, 1, 1);
            DateTime dataAtual = DateTime.Now;
            TimeSpan span = dataAtual - membroModel.DataDeNascimento;
            membroModel.Idade = (zeroTime + span).Year;
            membroModel.LinksGithub = new GraficoAtividadesModel(links);

            return View(membroModel);
        }

        public JsonResult MembroAutoComplete(string term)
        {
            IList<Membro> MembrosEncontrados = null;

            if (string.IsNullOrEmpty(term))
            {
                MembrosEncontrados = dataBase.BuscarTodosMembros();
            }
            else
            {
                MembrosEncontrados = dataBase.BuscarPorNome(term);
            }

            var json = MembrosEncontrados.Select(x => new { label = x.Nome });

            return Json(json, JsonRequestBehavior.AllowGet); 
        }

        public ActionResult GraficoDeAtividades(int id)
        {
            List<LinkFork> links = dataBase.BuscarLinkPorIdMembro(id);

            return View(new GraficoAtividadesModel(links));
        }
    }
}