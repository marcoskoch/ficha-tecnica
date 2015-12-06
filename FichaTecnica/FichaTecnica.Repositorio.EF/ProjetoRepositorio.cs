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
        private readonly BaseDeDados db = new BaseDeDados();

        public IList<Projeto> BuscarProjetosDoUsuario(int IDUsuario)
        {
            using (db)
            {
                var projetos = from projeto in db.Projeto
                               where projeto.IdUsuario == IDUsuario
                               select projeto;
                        
                return projetos.ToList();
            }
        }

        public Projeto BuscarProjetoPorId(int IDProjeto)
        {
            using (db)
            {
                return db.Projeto.Find(IDProjeto);
            }
        }

        public IList<Projeto> BuscarTodosProjetos()
        {
            return db.Projeto.ToList();
        }

        public IList<Projeto> BuscarPorNome(string term)
        {
            return db.Projeto.Where(p => p.Nome.Contains(term)).ToList();
        }

        public int CadastrarNovoProjeto(Projeto Projeto)
        {
            using (db)
            {
                db.Entry(Projeto).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }
    }
}
