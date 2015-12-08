using FichaTecnica.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FichaTecnica.Models
{
    public class ProjetoModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Mínimo 3 caracteres")]
        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }

        public List<Usuario> Usuarios { get; set; }

    }
}