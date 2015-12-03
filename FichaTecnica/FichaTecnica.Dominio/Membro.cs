using System;

namespace FichaTecnica.Dominio
{
    public class Membro
    {
        public int Id { get; set; }

        public int Nome { get; set; }

        public int Email { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string Numero { get; set; }

        public string Foto { get; set; }

        public Cargo Cargo { get; set; }

        public int IdCargo { get; set; }

        public string Link { get; set; }
    }
}