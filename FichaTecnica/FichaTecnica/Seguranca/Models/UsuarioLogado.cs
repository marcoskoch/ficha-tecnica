using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FichaTecnica.Seguranca.Model
{
    public class UsuarioLogado
    {
        public string Email { get; set; }

        public string Perfil { get; set; }

        public UsuarioLogado(string email)
        {
            this.Email = email;
            this.Perfil = "Gerente"; // ou Lider (buscar do banco)
        }

        public bool TemPerfil(string nomePerfil)
        {
            return this.Perfil != null
                && this.Perfil == nomePerfil;
        }
    }
}