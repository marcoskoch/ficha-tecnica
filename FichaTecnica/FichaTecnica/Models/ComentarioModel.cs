using FichaTecnica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FichaTecnica.Models
{
    public class ComentarioModel
    {
        public string Assunto{ get; set; }

        public string Texto { get; set; }

        public Tipo Tipo { get; set; }

        public DateTime DataCriacao { get; set; }

        public int IdUsuario { get; set; }

        public int IdProjeto { get; set; }

        public ComentarioModel()
        {
        }
    }
}