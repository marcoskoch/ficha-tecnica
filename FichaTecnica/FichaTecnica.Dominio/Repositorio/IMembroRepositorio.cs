using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Dominio.Repositorio
{
    public interface IMembroRepositorio
    {
        IList<Membro> BuscarTodosMembros();
        IList<Membro> BuscarPorNome(string nome);
        IList<Membro> BuscarMembroPorProjeto(Projeto projeto);
    }
}
