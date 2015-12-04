using FichaTecnica.Dominio;
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
        [Autorizador]
        public ActionResult TelaInicial()
        {
            return View();
        }
    }
}