using FichaTecnica.Dominio;
using FichaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FichaTecnica.Controllers
{
    public class TelaInicialController : Controller
    {
        // GET: TelaInicial
        public ActionResult TelaInicial(string nomeMembroEquipe)
        {
            if(nomeMembroEquipe == null)
            {
                return View();
            }
            else
            {
                return View();
            }
            
        }


    }
}