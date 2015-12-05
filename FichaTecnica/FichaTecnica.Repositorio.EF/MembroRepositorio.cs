using FichaTecnica.Dominio.Repositorio;
﻿using FichaTecnica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnica.Repositorio.EF
{
    public class MembroRepositorio : IMembroRepositorio
    {
        private readonly BaseDeDados dataBase = new BaseDeDados();

        public IList<Membro> BuscarTodosMembros()
        {
            using (dataBase)
            {
                return dataBase.Membro.ToList();
            }
        }

        public IList<Membro> BuscarPorNome(string nome)
        {
            using (dataBase)
            {
                var membros = from membro in dataBase.Membro
                            where membro.Nome.Contains(nome)
                            select membro;

                return membros.ToList();
            }
        }

        public IList<Membro> BuscarMembroPorProjeto(Projeto projeto)
        {
            int idProjeto = projeto.Id;

            using (var dataBase = new BaseDeDados())
            {
                var query = from membro in dataBase.Membro
                            where membro.Projetos.Any(project => project.Id == idProjeto)
                            select membro;

                return query.ToList();
            }
        }

        public Membro BuscarPorId(int id)
        {
            var membro = dataBase.Membro.Include("Cargo").SingleOrDefault(m => m.Id == id);
            return membro;
        }

        public List<LinkFork> BuscarLinkPorIdMembro(int id)
        {
            using (var dataBase = new BaseDeDados())
            {
                return dataBase.LinkFork.Where(l => l.IdMembro.Equals(id)).ToList();
            }
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
                if(membro.IdCargo == 3)
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
            using (dataBase)
            {
                foreach(Membro membro in membros)
                {
                    membro.Cargo = dataBase.Cargo.SingleOrDefault(c => c.Id == membro.IdCargo);
                }

                return membros;
            }
        }
        
    }
}
