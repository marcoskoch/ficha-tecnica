﻿using FichaTecnica.Dominio;
using FichaTecnica.Dominio.Repositorio;
using FichaTecnica.Models;
using FichaTecnica.Repositorio.EF;
using FichaTecnica.Seguranca.Filters;
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
        private IComentarioRepositorio dataBaseComentario = new ComentarioRepositorio();

        [Autorizador]
        public ActionResult TelaDetalhes(int Id)
        {
            Projeto projeto = dataBase.BuscarProjetoPorId(Id);

            IList<Membro> membrosDoProjeto = dataBaseMembro.BuscarMembroPorProjeto(projeto);
            membrosDoProjeto = dataBaseMembro.BuscarCargoMembros(membrosDoProjeto);
            projeto.Membros = membrosDoProjeto;

            List<Usuario> usuarios = new List<Usuario>();

            foreach(var usuario in  projeto.Usuarios)
            {
                usuarios.Add(dataBaseUsuario.BuscarPorId(usuario.Id));
            }
               
            List<MembroDetalheProjetoModel> detalhesMembros = new List<MembroDetalheProjetoModel>();
            foreach (var membro in projeto.Membros)
            {
                MembroDetalheProjetoModel membroDetalheProjetoModel = new MembroDetalheProjetoModel(membro);
                List<LinkFork> link = dataBaseMembro.BuscarLinkMembroDoProjeto(projeto.Id,membro.Id);
                membroDetalheProjetoModel.LinksGithub = new GraficoAtividadesModel(link);
                detalhesMembros.Add(membroDetalheProjetoModel);

                List<Comentario>comentarios = dataBaseComentario.BuscarComentariosPorMembro(membroDetalheProjetoModel.Id);             
                foreach(var comentario in comentarios)
                {
                    if (comentario.Tipo == Tipo.POSITIVO)
                    {
                        membroDetalheProjetoModel.TotalComentariosPosivo++;
                    }
                    else
                        membroDetalheProjetoModel.TotalComentarioNegativo++;
                }
            }

            TelaDetalhesModel model = new TelaDetalhesModel();
            model.Projeto = projeto;
            model.Usuarios = usuarios;
            model.MembrosDoProjeto = detalhesMembros;

            return View(model);
        }
    }
}