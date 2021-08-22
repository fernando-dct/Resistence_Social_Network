using Resistence_Entity;
using Resistence_Entity.Interfaces;
using System.Linq;

namespace Resistence_Repository
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly BaseContext _context;
        public InventarioRepository(BaseContext context)
        {
            _context = context;
        }
        public Inventario BuscarItemInventario(int idRebelde, string item, int quantidade)
        {
            return _context.Inventarios.Where(x => x.IdRebelde == idRebelde && x.Item.ToLower() == item.ToLower() && x.Quantidade >= quantidade).FirstOrDefault();
        }
    }
}
