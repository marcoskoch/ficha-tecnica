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
        private IMembroRepositorio dataBaseMember = new FichaTecnica.Repositorio.EF.MembroRepositorio();

        [Autorizador]
        public ActionResult TelaInicial(/*int idUsuario*/)
        {
            int IDUsuario = 1;
            //TODO: Otimizar
            IList<Projeto> projetos = dataBase.BuscarProjetosDoUsuario(IDUsuario);        
            IList<Membro> membros = null;
            foreach (Projeto projeto in projetos)
            {
                membros = dataBaseMember.BuscarMembroPorProjeto(projeto);
                projeto.Membros = new List<Membro>();
                foreach (Membro membro in membros)
                {        
                    projeto.Membros.Add(membro);
                }
            }

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