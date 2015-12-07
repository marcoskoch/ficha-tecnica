using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Dominio.Repositorio
{
   public interface IProjetoRepositorio
    {
        IList<Projeto> BuscarProjetosDoUsuario(int idUsuario);
        Projeto BuscarProjetoPorId(int idProjeto);
        IList<Projeto> BuscarTodosProjetos();
        IList<Projeto> BuscarPorMembro(int idMembro);
        IList<Projeto> BuscarPorNome(string term);
        int CadastrarNovoProjeto(Projeto Projeto);
        
    }
}
