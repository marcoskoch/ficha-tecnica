﻿using FichaTecnica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FichaTecnica.Models
{
    public class MembroDetalheProjetoModel
    {
        public string Foto { get; set; }
        public Cargo cargo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public ICollection<Projeto> Projetos { get; set; }
        public GraficoAtividadesModel LinksGithub { get; set; }

        public MembroDetalheProjetoModel(Membro entity)
        {
            this.Foto = entity.Foto;
            this.cargo = entity.Cargo;
            this.Nome = entity.Nome;
            this.Email = entity.Email;
            this.Projetos = entity.Projetos;
        }
    }
}