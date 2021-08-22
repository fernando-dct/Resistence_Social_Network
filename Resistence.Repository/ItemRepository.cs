using Resistence_Entity;
using Resistence_Entity.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Resistence_Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly BaseContext _context;
        public ItemRepository(BaseContext context)
        {
            _context = context;
            context.Itens.Add(new Item { Nome = "arma", Pontuacao = 4 });
            context.Itens.Add(new Item { Nome = "municao", Pontuacao = 3 });
            context.Itens.Add(new Item { Nome = "agua", Pontuacao = 2 });
            context.Itens.Add(new Item { Nome = "comida", Pontuacao = 1 });
            context.SaveChanges();
        }

        public IList<Item> BuscarItens()
        {
            return _context.Itens.ToList();
        }

        public Item BuscarItem(string item)
        {
            return _context.Itens.FirstOrDefault(x => x.Nome.ToLower() == item.ToLower());
        }
    }
}
