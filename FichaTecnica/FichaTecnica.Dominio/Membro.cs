using System;
using System.Collections.Generic;

namespace FichaTecnica.Dominio
{
    public class Membro
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public DateTime DataCriacao { get; set; }

        public string Telefone { get; set; }

        public string Foto { get; set; }

        public Cargo Cargo { get; set; }

        public int IdCargo { get; set; }

        public ICollection<Projeto> Projetos { get; set; }
    }
}