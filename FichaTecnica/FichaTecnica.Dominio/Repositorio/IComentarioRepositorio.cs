using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Dominio.Repositorio
{
    public interface IComentarioRepositorio
    {
        Comentario BuscarPorId(int id);
        List<Comentario> BuscarComentariosPorMembro(int id);
        int Criar(Comentario comentario);
        int AtualizarComentario(Comentario comentario);
    }
}
