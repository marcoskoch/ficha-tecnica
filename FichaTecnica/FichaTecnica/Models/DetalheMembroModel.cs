using FichaTecnica.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FichaTecnica.Models
{
    public class DetalheMembroModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DataDeNascimento { get; set; }

        public int Idade { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DataCriacao { get; set; }

        public string Telefone { get; set; }

        public string Foto { get; set; }

        public string Cargo { get; set; }

        public List<Comentario> Comentarios { get; set; }

        public GraficoAtividadesModel LinksGithub { get; set; }

        public DetalheMembroModel(Membro membro)
        {
            Id = membro.Id;
            Nome = membro.Nome;
            Email = membro.Email;
            DataDeNascimento = membro.DataDeNascimento;
            DataCriacao = membro.DataCriacao;
            Telefone = membro.Telefone;
            Cargo = membro.Cargo.Descricao;
            Foto = membro.Foto;
        }

    }
}