using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Dominio.Repositorio
{
    public interface IComentarioRepositorio
    {
        List<Comentario> BuscarComentariosPorMembro(int id);
        int Criar(Comentario comentario);
    }
}
