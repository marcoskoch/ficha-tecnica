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

        public IList<Projeto> BuscarProjetosDoUsuario(int idUsuario)
        {
            using (db)
            {
                return db.Projeto.Include("Usuarios")
                    .Where(p => p.Usuarios.FirstOrDefault(u => u.Id == idUsuario) != null).ToList();
            }
        }

        public IList<Projeto> BuscarPorMembro(int idMembro)
        {
            using (db)
            {
                return db.Projeto.Include("Membros")
                    .Where(p => p.Membros.FirstOrDefault(m => m.Id == idMembro) != null).ToList();
            }
        }

        public Projeto BuscarProjetoPorId(int idProjeto)
        {
            using (db)
            {
                return db.Projeto.Include("Usuarios").FirstOrDefault(p => p.Id == idProjeto);
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
