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

        public ICollection<Usuario> Usuarios { get; set; }

        public ICollection<Membro> Membros { get; set; }

        public Projeto()
        {
            Usuarios = new List<Usuario>();
        }
    }
}