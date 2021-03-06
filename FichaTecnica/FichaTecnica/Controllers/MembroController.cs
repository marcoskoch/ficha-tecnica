﻿using FichaTecnica.Dominio;
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
    
    public class MembroController : Controller
    {

        private IMembroRepositorio membroRepositorio = new MembroRepositorio();
        private IProjetoRepositorio projetoRepositorio = new ProjetoRepositorio();
        private IComentarioRepositorio comentarioRepositorio = new ComentarioRepositorio();

        [Autorizador]
        public ActionResult FichaMembro(int id)
        {
            var membroModel = new DetalheMembroModel(membroRepositorio.BuscarPorId(id));
            List<LinkFork> links = membroRepositorio.BuscarLinkPorIdMembro(id);
            List<Comentario> comentarios = comentarioRepositorio.BuscarComentariosPorMembro(id);

            DateTime zeroTime = new DateTime(1, 1, 1);
            DateTime dataAtual = DateTime.Now;
            TimeSpan span = dataAtual - membroModel.DataDeNascimento;
            membroModel.Idade = (zeroTime + span).Year;
            membroModel.LinksGithub = new GraficoAtividadesModel(links);
            membroModel.Comentarios = comentarios;

            return View(membroModel);
        }

        [Autorizador]
        public JsonResult MembroAutoComplete(string term)
        {
            IList<Membro> MembrosEncontrados = null;

            if (string.IsNullOrEmpty(term))
            {
                MembrosEncontrados = membroRepositorio.BuscarTodosMembros();
            }
            else
            {
                MembrosEncontrados = membroRepositorio.BuscarPorNome(term);
            }

            var json = MembrosEncontrados.Select(x => new { label = x.Nome });

            return Json(json, JsonRequestBehavior.AllowGet); 
        }

        [Autorizador]
        public JsonResult ProjetoAutoComplete(int idMembro = 0)
        {
            IList<Projeto> projetosEncontrados = null;

            if (idMembro != 0)
            {
                projetosEncontrados = projetoRepositorio.BuscarPorMembro(idMembro);
            }
            else
            {
                projetosEncontrados = projetoRepositorio.BuscarTodosProjetos();
            }

            var json = projetosEncontrados.Select(x => new { label = x.Nome, value = x.Id});

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [Autorizador]
        public ActionResult AdicionarComentario(ComentarioModel model)
        {
            Comentario comentario = new Comentario();
            UsuarioLogado usuario = (UsuarioLogado)Session["USUARIO_LOGADO"];

            comentario.IdMembro = model.IdMembro;
            comentario.Assunto = model.Assunto;
            comentario.Texto = model.Texto;
            comentario.Tipo = model.Tipo;
            comentario.IdProjeto = model.IdProjeto;
            comentario.DataCriacao = DateTime.Now;


            if (usuario == null)
            {
                TempData["Mensagem"] = "Você precisa estar autenticado!";
                return RedirectToAction("FichaMembro", "Membro", new { id = comentario.IdMembro });
            }
            else if (!ModelState.IsValid)
            {
                TempData["Mensagem"] = "Todos os campos são obrigatórios!";
                return RedirectToAction("FichaMembro", "Membro", new { id = comentario.IdMembro });
            }

            comentario.IdUsuario = usuario.Id;

            comentarioRepositorio.Criar(comentario);

            return RedirectToAction("FichaMembro", "Membro", new { id = comentario.IdMembro });
        }

        public ActionResult ExcluirComentario(int id)
        {
            UsuarioLogado usuario = (UsuarioLogado)Session["USUARIO_LOGADO"];
            var comentario = comentarioRepositorio.BuscarPorId(id);

           if(usuario.Id == comentario.IdUsuario)
            {
                comentario.Estado = Estado.INATIVO;
                comentarioRepositorio.AtualizarComentario(comentario);
            }
           else
            {
                TempData["Mensagem"] = "Você não possui permissão para excluir este comentário";
            }

            return RedirectToAction("FichaMembro", "Membro", new { id = comentario.IdMembro });
        }

        public ActionResult GraficoDeAtividades(int id)
        {
            List<LinkFork> links = membroRepositorio.BuscarLinkPorIdMembro(id);

            return View(new GraficoAtividadesModel(links));
        }

        public ActionResult MembroBusca(DetalheMembroModel membro)
        {
            var membroEncontrado = membroRepositorio.BuscarUmMembroPorNome(membro.Nome);
            return RedirectToAction("FichaMembro", "Membro", new { id = membroEncontrado.Id });
        }
    }
}