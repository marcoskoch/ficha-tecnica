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
    public class DetalhesProjetoController : Controller
    {
        private IProjetoRepositorio dataBase = new ProjetoRepositorio();
        private IMembroRepositorio dataBaseMembro = new MembroRepositorio();
        private IUsuarioRepositorio dataBaseUsuario = new UsuarioRepositorio();

        public ActionResult TelaDetalhes(int Id)
        {
            Projeto projeto = dataBase.BuscarProjetoPorId(Id);

            IList<Membro> membrosDoProjeto = dataBaseMembro.BuscarMembroPorProjeto(projeto);
            membrosDoProjeto = dataBaseMembro.BuscarCargoMembros(membrosDoProjeto);
            projeto.Membros = membrosDoProjeto;

            Usuario usuario = dataBaseUsuario.BuscarPorId(projeto.IdUsuario);

            List<MembroDetalheProjetoModel> detalhesMembros = new List<MembroDetalheProjetoModel>();
            foreach (var membro in membrosDoProjeto)
            {
                MembroDetalheProjetoModel membroDetalheProjetoModel = new MembroDetalheProjetoModel(membro);
                List<LinkFork> link = dataBaseMembro.BuscarLinkMembroDoProjeto(projeto.Id,membro.Id);
                membroDetalheProjetoModel.LinksGithub = new GraficoAtividadesModel(link);
                detalhesMembros.Add(membroDetalheProjetoModel);
            }
            

            TelaDetalhesModel model = new TelaDetalhesModel();
            model.Projeto = projeto;
            model.Usuario = usuario;
            model.LiderTecnico = dataBaseMembro.BuscarLiderTecnicoDoProjeto(membrosDoProjeto);
            model.MembrosDoProjeto = detalhesMembros;

            return View(model);
        }
    }
}