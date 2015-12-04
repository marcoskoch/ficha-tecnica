using FichaTecnica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FichaTecnica.Models
{
    public class GraficoAtividadesModel
    {

        public List<LinkFork> Links { get; private set; }

        public GraficoAtividadesModel(List<LinkFork> links)
        {
            Links = links;
        }
    }
}