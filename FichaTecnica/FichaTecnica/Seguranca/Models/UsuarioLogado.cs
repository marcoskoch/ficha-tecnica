using FichaTecnica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FichaTecnica.Seguranca.Model
{
    public class UsuarioLogado
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Perfil { get; set; }

        public UsuarioLogado(string email, int id)
        {
            this.Id = id;
            this.Email = email;
        }

        public UsuarioLogado(Usuario usuario)
        {
            this.Id = usuario.Id;
            this.Email = usuario.Email;
            this.Perfil = usuario.Permissao.Descricao;
        }

        public bool TemPerfil(string nomePerfil)
        {
            return this.Perfil != null
                && this.Perfil == nomePerfil;
        }
    }
}