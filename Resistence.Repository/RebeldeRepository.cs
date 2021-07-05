using Resistence_Entity;
using Resistence_Entity.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Resistence_Repository
{
    public class RebeldeRepository : IRebeldeRepository
    {
        private readonly BaseContext _context;
        public RebeldeRepository(BaseContext context)
        {
            _context = context;
        }

        public int adicionarRebelde(Rebelde rebelde)
        {
            _context.Rebeldes.Add(rebelde);
            _context.SaveChanges();
            return rebelde.IdRebelde;
        }

        public Rebelde buscarRebelde(int id)
        {
            return _context.Rebeldes.Find(id);
        }

        public IList<Rebelde> buscarTodosRebelde()
        {
            return _context.Rebeldes.ToList();
        }


        public bool atualizarDadosRebelde(Rebelde rebelde)
        {
            _context.Rebeldes.Update(rebelde);
            return _context.SaveChanges() > 0;
        }

        public bool atualizarDadosRebelde(List<Rebelde> rebeldes)
        {
            foreach (Rebelde rebelde in rebeldes)
            {
                _context.Rebeldes.Update(rebelde);
            }

            return _context.SaveChanges() > 0;
        }
    }
}
