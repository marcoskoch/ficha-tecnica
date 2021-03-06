﻿using FichaTecnica.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnica.Dominio;

namespace FichaTecnica.Repositorio.EF
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {
        private readonly BaseDeDados db = new BaseDeDados();


        public Comentario BuscarPorId(int id)
        {
            return db.Comentario.Find(id);
        }

        public List<Comentario> BuscarComentariosPorMembro(int id)
        {
            return db.Comentario.Include("Usuario").Include("Projeto").Where(c => c.IdMembro.Equals(id)).ToList();
        }

        public int Criar(Comentario comentario)
        {
            using (db)
            {
                db.Entry(comentario).State = System.Data.Entity.EntityState.Added;

                return db.SaveChanges();
            }
        }

        public int AtualizarComentario(Comentario comentario)
        {
            using (db)
            {
                db.Entry(comentario).State = System.Data.Entity.EntityState.Modified;

                return db.SaveChanges();
            }
        }
    }
}
