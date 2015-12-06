using FichaTecnica.Dominio;
using FichaTecnica.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Tests.Mocks
{
    class MembroRepositorioMock : IMembroRepositorio
    {
        public IList<Membro> BuscarTodosMembros()
        {
            return dataBase();
        }

        public IList<Membro> BuscarPorNome(string nome)
        {
            return dataBase().Where(u => u.Nome.Equals(nome)).ToList();
        }

        public IList<Membro> BuscarMembroPorProjeto(Projeto projeto)
        {
            int idProjeto = projeto.Id;

            var query = from membro in dataBase()
                        where membro.Projetos.Any(project => project.Id == idProjeto)
                        select membro;

            return query.ToList();
        }

        public Membro BuscarPorId(int id)
        {
            var membro = dataBase().SingleOrDefault(m => m.Id == id);
            return membro;
        }

        public Membro BuscarLiderTecnicoDoProjeto(IList<Membro> membros)
        {
            Membro liderTecnico = new Membro()
            {
                Nome = "Não há líder técnico no projeto",
                Email = "Não há líder técnico no projeto"
            };


            foreach (Membro membro in membros)
            {
                if (membro.IdCargo == 3)
                {
                    liderTecnico = new Membro()
                    {
                        Nome = membro.Nome,
                        Email = membro.Email
                    };

                }
            }

            return liderTecnico;
        }

        public IList<Membro> BuscarCargoMembros(IList<Membro> membros)
        {
            foreach (Membro membro in membros)
            {
                membro.Cargo = dataBaseCargos().SingleOrDefault(c => c.Id == membro.IdCargo);
            }

            return membros;
        }

        public Membro BuscarUmMembroPorNome(string nome)
        {
            var membros = dataBase();

            return membros.FirstOrDefault(m => m.Nome == nome);
        }



        public List<LinkFork> BuscarLinkMembroDoProjeto(int idProjeto, int idMembro)
        {
            return null;
        }

        public List<LinkFork> BuscarLinkPorIdMembro(int id)
        {
            return null;
        }




        private IList<Cargo> dataBaseCargos()
        {
            List<Cargo> cargos = new List<Cargo>();

            var Cargo1 = new Cargo()
            {
                Id = 1,
                Descricao = "Desenvolvedor"
            };

            var Cargo2 = new Cargo()
            {
                Id = 2,
                Descricao = "Testador"
            };

            var Cargo3 = new Cargo()
            {
                Id = 3,
                Descricao = "Líder Técnico"
            };

            cargos.Add(Cargo1);
            cargos.Add(Cargo2);
            cargos.Add(Cargo3);

            return cargos;
          
        }

        private IList<Membro> dataBase()
        {
            IList<Cargo> cargos = dataBaseCargos();

            var membros = new List<Membro>();
            
            var Projeto1 = new Projeto()
            {
                Id = 1,
                Nome = "projeto1",
                Descricao = "Descrição para o projeto1",
                DataInicio = new DateTime(15 / 02 / 2015),
            };

            var Projeto2 = new Projeto()
            {
                Id = 2,
                Nome = "Projeto2",
                Descricao = "Descrição para o projeto2",
                DataInicio = new DateTime(05 / 10 / 2015)
            };

            var listaProjetos = new List<Projeto>();
            listaProjetos.Add(Projeto1);
            listaProjetos.Add(Projeto2);

            var membro1 = new Membro()
            {
                Id = 1,
                Nome = "Ryu",
                Email = "Ryu@cwi.com.br",
                DataDeNascimento = new DateTime(12 / 12 / 2015),
                Telefone = "0102030405",
                Cargo = cargos[0],
                IdCargo = 1,
                Projetos = listaProjetos
            };

            var membro2 = new Membro()
            {
                Id = 2,
                Nome = "Ken",
                Email = "Ken@cwi.com.br",
                DataDeNascimento = new DateTime(05 / 06 / 1992),
                Telefone = "0102030405",
                Cargo = cargos[0],
                IdCargo = 1,
                Projetos = listaProjetos
            };

            membros.Add(membro1);
            membros.Add(membro2);

            return membros;
        }
    }
}
