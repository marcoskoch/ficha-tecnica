using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FichaTecnica.Dominio;

namespace FichaTecnica.Models
{
    public class TelaInicialModel
    {
        public List<Projeto> projetos { get; set; }
        public List<int> QuantidadeMembros { get; set; }

        public TelaInicialModel()
        {

        }

    }
    
}