using FichaTecnica.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FichaTecnica.Models
{
    public class ComentarioModel
    {
        [Required]
        public string Assunto{ get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public Tipo Tipo { get; set; }

        public DateTime DataCriacao { get; set; }

        public int IdUsuario { get; set; }

        [Required]
        public int IdProjeto { get; set; }

        public int IdMembro { get; set; }

        public ComentarioModel()
        {
        }
    }
}