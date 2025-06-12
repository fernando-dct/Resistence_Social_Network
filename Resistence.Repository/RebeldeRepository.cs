using Resistence_Entity;
using Resistence_Entity.Interfaces;
using System.Collections.Generic;

namespace Resistence_Repository
{
    public class RebeldeRepository(BaseContext context) : IRebeldeRepository
    {
        private readonly BaseContext _context = context;

        public int AdicionarRebelde(Rebelde rebelde)
        {
            _context.Rebeldes.Add(rebelde);
            _context.SaveChanges();
            return rebelde.IdRebelde;
        }

        public Rebelde BuscarRebelde(int id)
        {
            return _context.Rebeldes.Find(id);
        }

        public IList<Rebelde> BuscarTodosRebelde()
        {
            return [.. _context.Rebeldes];
        }


        public bool AtualizarDadosRebelde(Rebelde rebelde)
        {
            _context.Rebeldes.Update(rebelde);
            return _context.SaveChanges() > 0;
        }

        public bool AtualizarDadosRebelde(List<Rebelde> rebeldes)
        {
            foreach (Rebelde rebelde in rebeldes)
            {
                _context.Rebeldes.Update(rebelde);
            }

            return _context.SaveChanges() > 0;
        }
    }
}
