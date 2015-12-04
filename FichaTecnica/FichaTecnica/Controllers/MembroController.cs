using FichaTecnica.Dominio;
using FichaTecnica.Dominio.Repositorio;
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
    }
}