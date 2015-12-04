using FichaTecnica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FichaTecnica.Models
{
    public class GraficoAtividadesModel
    {

        public string URLBase { get; }

        public string URLBaseAPI { get; }

        public List<LinkFork> Links { get; private set; }

        public GraficoAtividadesModel(List<LinkFork> links)
        {

            URLBase = "https://github.com";
            URLBaseAPI = "https://api.github.com/repos";
            Links = links;
        }
    }
}