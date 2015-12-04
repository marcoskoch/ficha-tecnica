using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnica.Dominio.Repositorio;
using FichaTecnica.Dominio;

namespace FichaTecnica.Repositorio.EF
{
    public class ProjetoRepositorio : IProjetoRepositorio
    {
        private readonly BaseDeDados dataBase = new BaseDeDados();

        public List<Projeto> BuscarProjetosDoUsuario(int IDUsuario)
        {
            using (dataBase)
            {
                var projetos = from projeto in dataBase.Projeto
                               where projeto.IdUsuario == IDUsuario
                               select projeto;
            
                
                return projetos.ToList();
            }
        }
        

    }
}
