﻿using FichaTecnica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FichaTecnica.Models
{
    public class TelaDetalhesModel
    {
        public Projeto Projeto { get; set;}
        public Usuario Usuario { get; set;}
        public Membro LiderTecnico { get; set; }
        public IList<Membro> MembrosDoProjeto { get; set; }
    }
}