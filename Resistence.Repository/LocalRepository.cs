using Resistence_Entity;
using Resistence_Entity.Interfaces;
using System.Linq;

namespace Resistence_Repository
{
    public class LocalRepository(BaseContext context) : ILocalRepository
    {
        private readonly BaseContext _context = context;

        public Local BuscarLocal(int idRebelde)
        {
            return _context.Locais.Where(x => x.IdRebelde == idRebelde).FirstOrDefault();
        }

        public bool AtualizarLocal(Local local)
        {
            _context.Locais.Update(local);
            return (_context.SaveChanges() > 0);
        }
    }
}
