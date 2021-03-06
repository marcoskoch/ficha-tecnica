﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Dominio
{
    public class Usuario
    {

        public int Id { get; set; }

        public string Senha { get; set; }

        public string  Email { get; set; }

        public string Nome { get; set; }

        public Permissao Permissao { get; set; }

        public ICollection<Projeto> Projetos { get; set; }

        public int IdPermissao { get; set; }

    }
}
