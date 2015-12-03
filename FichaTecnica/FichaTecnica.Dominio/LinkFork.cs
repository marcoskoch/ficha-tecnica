using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Dominio
{
    public class LinkFork
    {
        public int Id { get; set; }

        public Membro Membro{ get; set; }

        public int IdMembro { get; set; }

        public int IdProjeto { get; set; }

        public Projeto Projeto { get; set; }

        public string URL { get; set; }

    }
}
