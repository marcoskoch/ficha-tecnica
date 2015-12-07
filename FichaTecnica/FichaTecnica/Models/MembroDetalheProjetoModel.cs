using FichaTecnica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FichaTecnica.Models
{
    public class MembroDetalheProjetoModel
    {
        public int Id { get; set; }
        public string Foto { get; set; }
        public Cargo cargo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public ICollection<Projeto> Projetos { get; set; }
        public int TotalComentariosPosivo { get; set; }
        public int TotalComentarioNegativo { get; set; }
        public GraficoAtividadesModel LinksGithub { get; set; }
        public DateTime DataUltimoCommit { get; set; }
        public string CommitSHA { get; set; }
        public string CommitLink { get; set; }
        public string Commitmenssage { get; set; }


        public MembroDetalheProjetoModel(Membro entity)
        {
            this.Id = entity.Id;
            this.Foto = entity.Foto;
            this.cargo = entity.Cargo;
            this.Nome = entity.Nome;
            this.Email = entity.Email;
            this.Projetos = entity.Projetos;
        }
    }
}