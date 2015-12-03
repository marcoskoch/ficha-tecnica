using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Dominio
{
    public class Comentario
    {

        public int Id { get; set; }

        public string Assunto { get; set; }

        public string Texto { get; set; }

        public Tipo Tipo { get; set; }

        public DateTime DataCriacao { get; set; }

        public Projeto Projeto { get; set; }

        public int IdProjeto { get; set; }

        public Usuario Usuario{ get; set; }

        public int IdUsuario { get; set; }
    }

    public enum Tipo
    {
        POSITIVO = 0,
        NEGATIVO = 1
    }
}
