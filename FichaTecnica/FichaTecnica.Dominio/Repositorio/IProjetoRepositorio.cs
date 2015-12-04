using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Dominio.Repositorio
{
   public interface IProjetoRepositorio
    {
        IList<Projeto> BuscarProjetosDoUsuario(int IDUsuario);
        //List<Projeto> BuscaTotalMembrosProjeto(List<Projeto> projetos);
    }
}
