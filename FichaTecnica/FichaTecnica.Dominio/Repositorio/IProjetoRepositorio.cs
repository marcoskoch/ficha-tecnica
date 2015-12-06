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
        Projeto BuscarProjetoPorId(int IDProjeto);
        IList<Projeto> BuscarTodosProjetos();
        IList<Projeto> BuscarPorNome(string term);
        int CadastrarNovoProjeto(Projeto Projeto);
    }
}
