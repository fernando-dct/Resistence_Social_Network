using Resistence_Entity;
using Resistence_Entity.Interfaces;
using System.Linq;

namespace Resistence_Repository
{
    public class InventarioRepository(BaseContext context) : IInventarioRepository
    {
        private readonly BaseContext _context = context;

        public Inventario BuscarItemInventario(int idRebelde, string item, int quantidade)
        {
            return _context.Inventarios
                .Where(x => x.IdRebelde == idRebelde 
                    && x.Item.Equals(item, System.StringComparison.CurrentCultureIgnoreCase) 
                    && x.Quantidade >= quantidade)
                .FirstOrDefault();
        }
    }
}
