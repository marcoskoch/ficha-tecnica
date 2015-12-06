using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnica.Dominio.Repositorio;
using FichaTecnica.Dominio;

namespace FichaTecnica.Tests.Mocks
{
    public class TelaInicialMock : IProjetoRepositorio
    {
        public IList<Projeto> BuscarProjetosDoUsuario(int IDUsuario)
        {
            var Queryable = from projeto in DataBase()
                            where projeto.IdUsuario == IDUsuario
                            select projeto;
            return Queryable.ToList();

        }

        private IList<Projeto> DataBase()
        {
            var projetos = new List<Projeto>();

            var projeto1 = new Projeto()
            {
                Id = 1,
                Nome = "Projeto de Mock",
                DataInicio = new DateTime(12 / 12 / 2015),
                Descricao = "Projeto De Mock Para Teste",
                Usuario = new Usuario(),
                IdUsuario = 1

            };

            projetos.Add(projeto1);
            return projetos;
        }

        public Projeto BuscarProjetoPorId(int IDProjeto)
        {
            return null;
        }

        public IList<Projeto> BuscarTodosProjetos()
        {
            throw new NotImplementedException();
        }

        public IList<Projeto> BuscarPorNome(string term)
        {
            throw new NotImplementedException();
        }

        public int CadastrarNovoProjeto(Projeto Projeto)
        {
            throw new NotImplementedException();
        }
    }
}
