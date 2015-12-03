using System;
using System.Collections;
using System.Collections.Generic;

namespace FichaTecnica.Dominio
{
    public class Projeto
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }

        public string Descricao { get; set; }

        public Usuario Usuario{ get; set; }

        public int IdUsuario { get; set; }

        public ICollection<Membro> Membros  { get; set; }

    }
}