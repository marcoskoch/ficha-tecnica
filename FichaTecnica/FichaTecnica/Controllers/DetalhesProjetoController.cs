using FichaTecnica.Dominio;
using FichaTecnica.Dominio.Repositorio;
using FichaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FichaTecnica.Controllers
{
    public class DetalhesProjetoController : Controller
    {
        private IProjetoRepositorio dataBase = new FichaTecnica.Repositorio.EF.ProjetoRepositorio();
        private IMembroRepositorio dataBaseMembro = new FichaTecnica.Repositorio.EF.MembroRepositorio();
        private IUsuarioRepositorio dataBaseUsuario = new FichaTecnica.Repositorio.EF.UsuarioRepositorio();

        public ActionResult TelaDetalhes(int Id)
        {
            Projeto projeto = dataBase.BuscarProjetoPorId(Id);

            IList<Membro> membrosDoProjeto = dataBaseMembro.BuscarMembroPorProjeto(projeto);
            membrosDoProjeto = dataBaseMembro.BuscarCargoMembros(membrosDoProjeto);
            projeto.Membros = membrosDoProjeto;

            Usuario usuario = dataBaseUsuario.BuscarPorId(projeto.IdUsuario);

            TelaDetalhesModel model = new TelaDetalhesModel();
            model.Projeto = projeto;
            model.Usuario = usuario;
            model.LiderTecnico = dataBaseMembro.BuscarLiderTecnicoDoProjeto(membrosDoProjeto);
            model.MembrosDoProjeto = membrosDoProjeto;

            return View(model);
        }
    }
}