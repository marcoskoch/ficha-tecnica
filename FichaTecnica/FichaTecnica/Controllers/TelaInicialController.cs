using FichaTecnica.Dominio;
using FichaTecnica.Dominio.Repositorio;
using FichaTecnica.Models;
using FichaTecnica.Repositorio.EF;
using FichaTecnica.Seguranca.Filters;
using FichaTecnica.Seguranca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FichaTecnica.Controllers
{
    [Autorizador]
    public class TelaInicialController : Controller
    {
        private IProjetoRepositorio dataBase = new ProjetoRepositorio();
        private IMembroRepositorio dataBaseMember = new MembroRepositorio();

        public ActionResult TelaInicial()
        {
            UsuarioLogado usuarioLogado = HttpContext.Session["USUARIO_LOGADO"] as UsuarioLogado;
            IList<Projeto> projetos = dataBase.BuscarProjetosDoUsuario(usuarioLogado.Id);        
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